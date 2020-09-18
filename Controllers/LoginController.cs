using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestApi.Models.UserModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Login(string userName, string pass)
        {
            User login = new User();
            login.UserName = userName;
            login.Password = pass;
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }

            return response;
        }

        private string GenerateJSONWebToken(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var crdential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.UserEmaildId),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["jwt:Issuer"],
                 audience: _config["jwt:Issuer"],
                 claims,
                 expires: DateTime.Now.AddMinutes(120),
                 signingCredentials: crdential
            );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;

        }

        private User AuthenticateUser(User login)
        {
            User user = null;
            if (login.UserName == "darshit" && login.Password == "123465")
            {
                user = new User
                {
                    UserName = "darshit",
                    UserEmaildId = "darshit.parkhiya@gmail.com",
                    Password = "123465"
                };
            }

            return user;
        }

        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claims = identity.Claims.ToList();
            var userName = claims[0].Value;
            return "Welcome To:" + userName;
        }

        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value1", "Value2" };
        }
    }
}