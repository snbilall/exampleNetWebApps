using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.DbContexts;
using WebApiProj.Models;

namespace WebApiProj.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var identityContext = serviceProvider.GetRequiredService<IdentityDbContext>();
            var appContext = serviceProvider.GetRequiredService<AppDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            identityContext.Database.EnsureCreated();
            String[] roles = { "Manager", "Editor" };

            if (!identityContext.Roles.Any())
            {
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if (!identityContext.Users.Any())
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "bilal",
                    Email = "bilal@burgan.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                await userManager.CreateAsync(user, "Burgan3461.");
            }

            if (!appContext.Users.Any())
            {
                var todo = new Todo
                {
                    Name = "Özel not",
                    isDone = false,
                    Description = "Kullanıcıya has not"
                };
                await appContext.Todos.AddAsync(todo);
                var user = new User
                {
                    Name = "Bilal",
                    IdentityNumber = "1111111111",
                    Job = "Engineer"
                };
                await appContext.Users.AddAsync(user);
                var userTodo = new UserTodo
                {
                    UserId = user.Id,
                    TodoId = todo.Id
                };
                await appContext.UserTodos.AddAsync(userTodo);
                await appContext.SaveChangesAsync();
            }
        }
    }
}
