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
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService=departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.UserName) || string.IsNullOrEmpty(createDto.Password))
                return BadRequest("Username and password is required.");
            if(await _employeeService.IsExist(createDto.UserName))
                return BadRequest("Username exist.");
            if (createDto.DepartmentID.HasValue && !await _departmentService.IsExist(createDto.DepartmentID.Value))
                return BadRequest("Department not exist!!!");

            var result = await _employeeService.CreateAsync(createDto);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _employeeService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,
                                                [FromBody] EmployeeUpdateDto updateDto)
        {
            if (string.IsNullOrEmpty(updateDto.UserName))
                return BadRequest("Username is required.");
            if(!await _employeeService.IsExist(id))
                return BadRequest("Employee not exist!!!");
            if (updateDto.DepartmentID.HasValue && !await _departmentService.IsExist(updateDto.DepartmentID.Value))
                return BadRequest("Department not exist!!!");

            var result = await _employeeService.UpdateAsync(id, updateDto);
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
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
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
