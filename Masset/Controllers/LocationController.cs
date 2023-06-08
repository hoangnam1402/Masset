using Business.Interfaces;
using Contracts;
using Contracts.Dtos.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _locationService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] LocationCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name))
                return BadRequest("Name is required.");
            if (await _locationService.IsExist(createDto.Name))
                return BadRequest("Location name has been used before!!!");

            var result = await _locationService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] LocationUpdateDto updateDTO)
        {
            if (!await _locationService.IsExist(id))
                return BadRequest("Location not exist!!!");
            if (await _locationService.IsDelete(id))
                return BadRequest("Location have been delete!!!");

            var result = await _locationService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _locationService.IsExist(id))
                return BadRequest("Location not exist!!!");
            if (await _locationService.IsDelete(id))
                return BadRequest("Location has been deleted before.");

            var result = await _locationService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _locationService.IsExist(id))
                return BadRequest("No Location with id: " + id);
            if (await _locationService.IsDelete(id))
                return BadRequest("Location has been deleted.");

            var result = await _locationService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _locationService.GetAll();
            return Ok(result);
        }

    }
}
