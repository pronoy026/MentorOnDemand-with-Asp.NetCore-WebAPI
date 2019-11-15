using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DotNetMentorOnDemandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly SignInManager<UserModel> signInManager;
        private readonly UserManager<UserModel> userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserAccountsController(UserManager<UserModel> userManager, 
            SignInManager<UserModel> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }

        [Route("login")]
        [HttpPost]

        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                //sending response if succeeded
                var appUser = userManager.Users.Single(r => r.Email == model.Email);
                var token = await GenerateJwtToken(model.Email, appUser);
                var response = new TokenResponseDto
                {
                    Token = token,
                    Email = model.Email,
                    Role = model.Role
                };
                return Ok(response);
            }
            return BadRequest(result);
        }

        [Route("logout")]
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Logout([FromBody] UserLoginDto model)
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                //InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "LogOut Failed");
            }
            return Ok();
        }

        [Route("register")]
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new UserModel
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Experience = model.Experience,
                LinkedInUrl = model.LinkedinUrl,
                IsBlocked = false
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // role name
                var roleName = roleManager.Roles.
                    FirstOrDefault(r => r.Id == model.Role.ToString()).NormalizedName;
                var res = await userManager.AddToRoleAsync(user, roleName);
                if (res.Succeeded)
                {
                    //sending response if succeeded
                    var appUser = userManager.Users.Single(r => r.Email == model.Email);
                    var token = await GenerateJwtToken(model.Email, appUser);
                    var response = new TokenResponseDto
                    {
                        Token = token,
                        Email = model.Email,
                        Role = model.Role
                    };
                    return Ok(response);
                }
                return BadRequest(res.Errors);
            }
            return BadRequest(result.Errors);
        }

        private async Task<string> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(
                Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
                );
            var Token = new JwtSecurityTokenHandler().WriteToken(token);
            //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            return Token;
        }
    }
}
