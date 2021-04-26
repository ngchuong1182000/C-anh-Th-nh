using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;
using LibraryManagementPortal.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementPortal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserRepository _repoUser;
        private readonly IRoleRepository _repoRole;
        private readonly IConfiguration _configuration;
        public AuthenticateController(IUserRepository repoUser, IRoleRepository repoRole, IConfiguration configuration)
        {
            _repoUser = repoUser;
            _repoRole = repoRole;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _repoUser.GetUserByEmail(model.Email);
            if (user != null && user.Password == model.Password)
            {
                var userRoles = user.RoleId;
                IEnumerable<Role> roles = _repoRole.GetOne(userRoles, u=>u.Users);
                string nameRole="";
                foreach (Role role in roles)
                {
                    nameRole = role.Name;
                }
                var authClaims = new List<Claim>
                {
                    new Claim("email", user.email),
                    new Claim("id", user.Id),
                    new Claim("role", nameRole)
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Ok(
                new { 
                    error = "Email or Password is not Connect !!!"
                });
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var userExists = _repoUser.GetUserByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            User user = new User()
            {
                Id = Util.generateID(),
                Name = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                email = model.Email,
                Password = model.Password,
                RoleId = "2"
            };
            _repoUser.Insert(user);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}
