using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.Repositories.Interfaces;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeDbRepository _employeeDbRepository;

        public EmployeesController(IEmployeeDbRepository employeeDbRepository)
        {
            _employeeDbRepository = employeeDbRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeDbRepository.GetEmployeesFromDb();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesDetails([FromRoute] int id)
        {
            var res = await _employeeDbRepository.GetEmployeesDetailsFromDb(id);

            if (res is null)
                return NotFound("Employee not found");
            return Ok(res);
        }





    }
}