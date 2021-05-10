using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Tables;
using Project_X_API.Services;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExplosivesDataController : ControllerBase
    {
        private readonly ILogger<UsersLoginInfoController> _logger;
        private readonly ExplosivesDataServices _explosivesDataServices;

        public ExplosivesDataController(ILogger<UsersLoginInfoController> logger, ExplosivesDataServices explosivesDataServices)
        {
            _logger = logger;
            _explosivesDataServices = explosivesDataServices;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ExplosiveData explosiveDataToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _explosivesDataServices.AddExplosivesDataToDataBase(explosiveDataToAdd);

            return Accepted(explosiveDataToAdd);
        }

        [HttpGet]
        public ActionResult<List<ExplosiveData>> GetAll()
        {
            return _explosivesDataServices.GetAllExplosivesDatas();
        }
    }
}