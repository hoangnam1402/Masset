using Business.Interfaces;
using Contracts;
using Contracts.Dtos.BrandsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _brandService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BrandCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name))
                return BadRequest("Name is required.");
            if (await _brandService.IsExist(createDto.Name))
                return BadRequest("Brand name has been used before!!!");

            var result = await _brandService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] BrandUpdateDto updateDTO)
        {
            if (!await _brandService.IsExist(id))
                return BadRequest("Brand not exist!!!");

            var result = await _brandService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _brandService.IsExist(id))
                return BadRequest("Brand not exist!!!");
            if (await _brandService.IsDelete(id))
                return BadRequest("Brand has been deleted before.");

            var result = await _brandService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _brandService.IsExist(id))
                return BadRequest("No Brand with id: " + id);

            var result = await _brandService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAll();
            return Ok(result);
        }

    }
}
