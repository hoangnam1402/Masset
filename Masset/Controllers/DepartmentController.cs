using Business.Interfaces;
using Contracts;
using Contracts.Dtos.DepartmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _departmentService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name))
                return BadRequest("Name is required.");
            if (await _departmentService.IsExist(createDto.Name))
                return BadRequest("Name has been used before!!!");

            var result = await _departmentService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] DepartmentUpdateDto updateDTO)
        {
            if (!await _departmentService.IsExist(id))
                return BadRequest("Department not exist!!!");

            var result = await _departmentService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _departmentService.IsExist(id))
                return BadRequest("Department not exist!!!");
            if (await _departmentService.IsDelete(id))
                return BadRequest("Department has been deleted before.");

            var result = await _departmentService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _departmentService.IsExist(id))
                return BadRequest("No Department with id: " + id);

            var result = await _departmentService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Not Found !");
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _departmentService.GetAll();
            return Ok(result);
        }

    }
}
