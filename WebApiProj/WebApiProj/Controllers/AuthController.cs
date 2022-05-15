using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApiProj.DbContexts;
using WebApiProj.Models;
using WebApiProj.Response;

namespace WebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AspNetCoreDersim"));

                var token = new JwtSecurityToken (
                    issuer: "https://localhost:44339",
                    audience: "https://localhost:44339",
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new Response<Object>(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiresAt = token.ValidTo
                }));
            }
            else
            {
                return BadRequest("Hatalı parola");
            }
        }
    }
}   