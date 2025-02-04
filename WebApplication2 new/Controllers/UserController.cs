
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Name = "hudu", Email = "h@gmail.com", Password = "1234",Role="Admin" },
            new User { Id = 1, Name = "huedu", Email = "hc@gmail.com", Password = "123334",Role="User" }
        };

        private readonly IConfiguration config;


        public UserController(IConfiguration _config)
        {
            config = _config;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User u)
        {
            users.Add(u);
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login loginUser)
        {
            var user = users.FirstOrDefault(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var token = GenerateToken(user);
            return Ok(new { token });
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Iss,config["jwt:issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud,config["jwt:audience"]),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
            };
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(1));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
