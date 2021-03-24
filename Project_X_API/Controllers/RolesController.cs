using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;
        private readonly RolesRepository _rolesRepository;

        public RolesController(ILogger<RolesController> logger, RolesRepository rolesRepository)
        {
            _logger = logger;
            _rolesRepository = rolesRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Role roleToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _rolesRepository.AddRole(roleToAdd);

            return Accepted(roleToAdd);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_rolesRepository.GetAllRoles());
        }
    }
}