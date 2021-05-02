﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;
using Project_X_API.DTOS;
using Project_X_API.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserServices _userServices;
        private readonly UserRepository _userRepository;

        public AuthenticationController(ILogger<AuthenticationController> logger, UserServices userServices, IConfiguration config, UserRepository userRepository)
        {
            _logger = logger;
            _configuration = config;
            _userRepository = userRepository;
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDTO userToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userToAdd.Password);
            _userServices.AddUserToDataBase(new User() { Username = userToAdd.Username, PasswordHash = passwordHash, Token = userToAdd.Token });

            return Accepted(userToAdd);
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDTO userToAuthenticate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (userToAuthenticate?.Username == null || userToAuthenticate.Password == null)
            {
                return BadRequest();
            }
            
            var userAccount = _userServices.GetAllUsers().FirstOrDefault(x => x.Email == userToAuthenticate.Username);
            if (userAccount == null && !BCrypt.Net.BCrypt.Verify(userToAuthenticate.Password, userAccount.PasswordHash))
            {
                return BadRequest("Invalid credentials");
            }

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", userAccount.Id.ToString()),
                new Claim("UserName", userAccount.Username),
                new Claim("Email", userAccount.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}