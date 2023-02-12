using Business.Interfaces;
using Contracts.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto employeeDto)
        {
            if (string.IsNullOrEmpty(employeeDto.UserName) || string.IsNullOrEmpty(employeeDto.Password))
                return BadRequest("Username and password is required.");
            if(await _employeeService.IsExist(employeeDto.UserName))
                return BadRequest("Username exist.");

            var result = await _employeeService.CreateEmployee(employeeDto);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }
    }
}
