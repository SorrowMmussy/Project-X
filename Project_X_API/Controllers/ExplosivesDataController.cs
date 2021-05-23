using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ActionResult<List<ExplosiveData>> Search([FromQuery] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            return _explosivesDataServices.GetAllExplosivesDatas().Where(explosive =>
                explosive.Name.ToLowerInvariant().Contains(name.ToLowerInvariant())).ToList();
        }

        [HttpGet]
        public ActionResult<ExplosiveData> GetById([FromQuery] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            return _explosivesDataServices.GetAllExplosivesDatas().FirstOrDefault(explosive => explosive.Id == id);
        }

        [HttpPost]
        public IActionResult Edit([FromBody] ExplosiveData explosiveDataToEdit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _explosivesDataServices.EditExplosivesDataInDataBase(explosiveDataToEdit);

            return Accepted(explosiveDataToEdit);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _explosivesDataServices.DeleteExplosivesDataFromDataBase(id);

            return Accepted(id);
        }
    }
}