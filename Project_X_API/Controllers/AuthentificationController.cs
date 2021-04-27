using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;
using Project_X_API.DTOS;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserRepository _userRepository;

        public AuthenticationController(ILogger<AuthenticationController> logger, UserRepository userRepository)
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

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDTO userToAuthenticate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var account = _userRepository.GetAllUsers().SingleOrDefault(x => x.Email == userToAuthenticate.Username);
            if (account == null || !BCrypt.Net.BCrypt.Verify(userToAuthenticate.Password, account.PasswordHash))
            {
                return Unauthorized();
            }
            else
            {
                return Accepted(userToAuthenticate);
            }
        }
    }
}