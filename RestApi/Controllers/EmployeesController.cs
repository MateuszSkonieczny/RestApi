using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.DTO.Requests;
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
            var employees = await _employeeDbRepository.GetEmployeesFromDbAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesDetails([FromRoute] int id)
        {
            var res = await _employeeDbRepository.GetEmployeesDetailsFromDbAsync(id);

            if (res is null)
                return NotFound("Employee not found");
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequestDto employeeRequestDto)
        {
            var res = await _employeeDbRepository.AddEmployeeToDbAsync(employeeRequestDto);
            if (res)
                return Ok("Employee was added to database");
            
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequestDto employeeRequestDto, [FromRoute] int id)
        {
            var res = await _employeeDbRepository.UpdateEmployeeFromDb(employeeRequestDto, id);
            if (res)
                return Ok("Employee updated");

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var res = await _employeeDbRepository.DeleteEmployeeFromDb(id);
            if (res)
                return Ok("Employee deleted");

            return BadRequest();
        }

    }
}