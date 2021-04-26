using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;
using Project_X_API.DTOS;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthentificationController : ControllerBase
    {
        private readonly ILogger<AuthentificationController> _logger;
        private readonly UserRepository _userRepository;

        public AuthentificationController(ILogger<AuthentificationController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDTO userToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userToAdd.Password);
            _userRepository.AddUser(new User(){Username = userToAdd.Username, PasswordHash = passwordHash, Token = userToAdd.Token});

            return Accepted(userToAdd);
        }
    }
}