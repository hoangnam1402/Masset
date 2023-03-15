using Business.Interfaces;
using Contracts.Dtos.SettingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpPut]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateSettingDto updateRequest)
        {
            var result = await _settingService.UpdateAsync(updateRequest);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Something go wrong.");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _settingService.GetAsync();

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }
    }
}
