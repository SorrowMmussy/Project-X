using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TokenValidationController : ControllerBase
    {
        private readonly ILogger<TokenValidationController> _logger;
        private readonly TokenValidationRepository _tokenValidationRepository;

        public TokenValidationController(ILogger<TokenValidationController> logger, TokenValidationRepository tokenValidationRepository)
        {
            _logger = logger;
            _tokenValidationRepository = tokenValidationRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] TokenValidation tokenValidationToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _tokenValidationRepository.AddEmailVerification(tokenValidationToAdd);

            return Accepted(tokenValidationToAdd);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tokenValidationRepository.GetAllEmailRegistrations());
        }
    }
}