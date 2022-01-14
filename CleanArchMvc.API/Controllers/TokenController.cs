using CleanArchMvc.API.DTOs;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;
        public TokenController(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] Login login)
        {
            var result = Authenticate(login.Email, login.Password);
            if (result) {
                return GenerateToken(login);
            }
            else {
                ModelState.AddModelError(string.Empty, "Email or Password is invalid!");
                return BadRequest(ModelState);
            }
        }

        private bool Authenticate(string email, string password)
        {
            var email1 = "teste@gmail.com.br";
            var password1 = "123!@#456";

            if (email.Equals(email1) && password.Equals(password1))
                return true;
            return false;
        }

        private ActionResult<UserToken> GenerateToken(Login login)
        {
            var claims = new[] {
                new Claim("email", login.Email),
                new Claim("name", "teste"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var privateKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"])
                );

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var timeExpire = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: timeExpire,
                signingCredentials: credentials
            );
            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = timeExpire
            };
        }
    }
}
