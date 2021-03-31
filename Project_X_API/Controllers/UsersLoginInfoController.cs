using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersLoginInfoController : ControllerBase
    {
        private readonly ILogger<UsersLoginInfoController> _logger;
        private readonly UserRepository _userRepository;

        public UsersLoginInfoController(ILogger<UsersLoginInfoController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] User userToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userRepository.AddUser(userToAdd);

            return Accepted(userToAdd);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAllUsers());
        }
    }
}