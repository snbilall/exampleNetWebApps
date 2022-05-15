using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using WebApiProj.Core;
using WebApiProj.Data;
using WebApiProj.DbContexts;
using WebApiProj.Models;

namespace WebApiProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionContext")));
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionContext")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters() {
                    ValidateIssuer = true,
                    ValidIssuer = "https://localhost:44339",
                    ValidateAudience = true,
                    ValidAudience = "https://localhost:44339",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AspNetCoreDersim"))
                };
            });

            // Dependency Injection
            services.AddRepositories();
            services.AddTransient<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            SeedData.InitializeAsync(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider).Wait();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
