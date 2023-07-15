using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using task_manager.Domain;
using task_manager.DTOs;
using task_manager.Repository;
using task_manager.Response;

namespace task_manager.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IUnitOfWork _context;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public AuthController(IUnitOfWork context, ILogger<AuthController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public ResponseResult Login([FromBody] LoginModel model)
        {
            // Validate the user credentials
            var user = _context.UserRepository.Get().SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
                return ResponseResult.ReturnFail("Email or password is incorrect");

            // Generate JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                };

            var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Issuer"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Return the token
            return ResponseResult.ReturnSuccess("Authentication Successful", tokenString);


        }

    }

}
