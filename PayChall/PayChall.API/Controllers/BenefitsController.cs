using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PayChall.API.Dtos;
using PayChall.API.Repository;
using PayChall.API.Services;

namespace PayChall.API.Controllers
{
    [Route("api/benefits")]
    public class BenefitsController : Controller
    {
        private IBenefitsRepository _repo;
        private ILogger<BenefitsController> _logger;
        private IMailService _mailService;
        public BenefitsController(ILogger<BenefitsController> logger,
            IMailService mailService, IBenefitsRepository repository)
        {
            _logger = logger;
            _mailService = mailService;
            _repo = repository;
        }

        [HttpGet("meta")]
        public ActionResult GetMeta()
        {
            try
            {
                var retval = _repo.GetMetaData();
                return Ok(retval);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Exception while getting benefits meta.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("costs")]
        public ActionResult GetCosts()
        {
            try
            {
                var retval = _repo.GetCosts();
                return Ok(retval);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Exception while getting benefit costs.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("discounts")]
        public ActionResult GetDiscounts()
        {
            try
            {
                var retval = _repo.GetDiscounts();
                return Ok(retval);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Exception while getting benefit costs.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("employees")]
        public ActionResult GetEmployees()
        {
            try
            {
                var retval = _repo.GetEmployees();
                return Ok(retval);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Exception while getting employees.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("employees/{id}")]
        public ActionResult GetEmployee(int id)
        {
            try
            {
                var retval = _repo.GetEmployee(id);
                return Ok(retval);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Exception while getting employee with ID ${id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("employees/{id}/elections", Name="GetEmployeeBenefitElections")]
        public ActionResult GetEmployeeBenefitElections(int id)
        {
            try
            {
                var retval = _repo.GetEmployeeElections(id);
                return Ok(retval);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Exception while getting employee with ID ${id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost("employees/{id}/elections")]
        public IActionResult CreateEmployeeElections(int id, [FromBody] BenefitElectionsForCreateDto elections)
        {
            if (elections == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_repo.EmployeeExists(id))
            {
                return NotFound();
            }

            var dto = _repo.AddElections(id, elections);

            if (!_repo.Save())
            {
                _logger.LogError($"Error handling create employee benefit elections for Employee ID {id}");
                return StatusCode(500, "Error while handling request for create Employee Benefit Elections");
            }

            _logger.LogInformation($"Employee benefit elections for Employee with id {id} was added (POST).");
            
            return CreatedAtRoute("GetEmployeeBenefitElections", new { id = dto.Employee.EmployeeId }, dto);
        }
    }
}
