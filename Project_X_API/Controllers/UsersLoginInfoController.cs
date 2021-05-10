using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Tables;
using Project_X_API.Services;
using System.Collections.Generic;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersLoginInfoController : ControllerBase
    {
        private readonly ILogger<UsersLoginInfoController> _logger;
        private readonly UserServices _userServices;

        public UsersLoginInfoController(ILogger<UsersLoginInfoController> logger, UserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult Add([FromBody] User userToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userServices.AddUserToDataBase(userToAdd);

            return Accepted(userToAdd);
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userServices.GetAllUsers();
        }
    }
}