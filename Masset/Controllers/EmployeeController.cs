using Business.Interfaces;
using Contracts;
using Contracts.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Authorization;
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

            var result = await _employeeService.CreateAsync(employeeDto);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetEmployee([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _employeeService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,
                                                [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            if (string.IsNullOrEmpty(employeeUpdateDto.UserName))
                return BadRequest("Username is required.");
            if(!await _employeeService.IsExist(id))
                return BadRequest("Employee not exist!!!");

            var result = await _employeeService.UpdateAsync(id, employeeUpdateDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!await _employeeService.IsExist(id))
                return BadRequest("Employee not exist!!!");
            if (await _employeeService.IsDelete(id))
                return BadRequest("Employee has been deleted before.");

            var result = await _employeeService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!await _employeeService.IsExist(id))
                return BadRequest("Not Employee with id: " + id);

            var result = await _employeeService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

    }
}
