using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyWebApiBasic.Data;
using MyWebApiBasic.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyWebApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private MyDBContext _context;
        private readonly AppSetting _appSettings;
        public UserController(MyDBContext context, IOptionsMonitor<AppSetting> optionsMonitor) {
        _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }
        [HttpPost]
        public IActionResult Validate(LoginModel _loginModel)
        {
            var user = _context.Users.SingleOrDefault(p => p.Password == _loginModel.Password
            && p.UserName == _loginModel.UserName);
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new APIResponse
                {
                    success = true,
                    message = "Thanh Cong",
                    data = GenerateToken(user)
                });

            }
        }
            private string GenerateToken(User user)
            {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.HoTen),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserName", user.UserName),
                    new Claim("Id", user.Id.ToString()),
                    //roles

                    new Claim("TokenId", Guid.NewGuid().ToString())

                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), 
                SecurityAlgorithms.HmacSha512Signature)
                           };
            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
            }
        
    }
}
