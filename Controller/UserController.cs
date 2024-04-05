using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using demo1.Models;
using demo1.Repositories;

namespace demo1.Controller
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("api/signup")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userRepository.AddUser(user);
            return CreatedAtAction("PostUser", new User { id = user.id }, user);
        }

        [HttpPost("api/login")]
        public async Task<ActionResult<string>> Login(User user)
        {
            var isValidUser = await _userRepository.ValidateUser(user);
            if (isValidUser)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(tokenString);
            }
            return Unauthorized();
        }

        // This is a protected endpoint, requires a valid JWT token
        [Authorize]
        [HttpGet("api/protected")]
        public IActionResult ProtectedEndpoint()
        {
            return Ok("This is a protected endpoint");
        }
    }
}
