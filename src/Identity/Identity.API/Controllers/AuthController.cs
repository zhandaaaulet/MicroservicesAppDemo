using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Identity.API.Dtos;
using Identity.API.Entities;
using Identity.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Identity.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository)); 
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserRegisterDto), (int)HttpStatusCode.Created)]
        public IActionResult Register([FromBody] UserRegisterDto userRegisterDTO)
        {
            userRegisterDTO.Username = userRegisterDTO.Username.ToLower();

            if (_authRepository.UserExists(userRegisterDTO.Username))
                return BadRequest("Username already exists!");

            var userToCreate = new User
            {
                Name = userRegisterDTO.Name,
                Surname = userRegisterDTO.Surname,
                Username = userRegisterDTO.Username,
                Birthday = Convert.ToDateTime(userRegisterDTO.Birthday),
                GroupId = userRegisterDTO.GroupId
            };

            var createdUser = _authRepository.Register(userToCreate, userRegisterDTO.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDTO)
        {
            var user = _authRepository.Login(userLoginDTO.Username.ToLower(), userLoginDTO.Password);

            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, ClaimsIdentity.DefaultNameClaimType),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
