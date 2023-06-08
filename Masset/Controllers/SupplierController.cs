using Business.Interfaces;
using Contracts;
using Contracts.Dtos.SupplierDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _supplierService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] SupplierCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name))
                return BadRequest("Name is required.");
            if (await _supplierService.IsExist(createDto.Name))
                return BadRequest("Supplier name has been used before!!!");

            var result = await _supplierService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] SupplierUpdateDto updateDTO)
        {
            if (!await _supplierService.IsExist(id))
                return BadRequest("Supplier not exist!!!");
            if (await _supplierService.IsDelete(id))
                return BadRequest("Supplier have been delete!!!");

            var result = await _supplierService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _supplierService.IsExist(id))
                return BadRequest("Supplier not exist!!!");
            if (await _supplierService.IsDelete(id))
                return BadRequest("Supplier has been deleted before.");

            var result = await _supplierService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _supplierService.IsExist(id))
                return BadRequest("No Supplier with id: " + id);
            if (await _supplierService.IsDelete(id))
                return BadRequest("Supplier has been deleted.");

            var result = await _supplierService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierService.GetAll();
            return Ok(result);
        }

    }
}
