using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersPersonalInfoController : ControllerBase
    {
        private readonly ILogger<UsersPersonalInfoController> _logger;
        private readonly UserDataRepository _userDataRepository;

        public UsersPersonalInfoController(ILogger<UsersPersonalInfoController> logger, UserDataRepository userDataRepository)
        {
            _logger = logger;
            _userDataRepository = userDataRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserData userDataToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userDataRepository.AddUserData(userDataToAdd);

            return Accepted(userDataToAdd);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userDataRepository.GetAllUsersData());
        }
    }
}