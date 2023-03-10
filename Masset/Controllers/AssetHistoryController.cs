using Business.Interfaces;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetHistoryController : ControllerBase
    {
        private readonly IAssetHistoryService _assetHistoryService;
        public AssetHistoryController(IAssetHistoryService assetHistoryService)
        {
            _assetHistoryService = assetHistoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                       CancellationToken cancellationToken)
        {
            var responses = await _assetHistoryService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpGet("GetUnread")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _assetHistoryService.GetUnread();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _assetHistoryService.IsExist(id))
                return BadRequest("No AssetHistory with id: " + id);

            var result = await _assetHistoryService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Read([FromRoute] int id)
        {
            if (!await _assetHistoryService.IsExist(id))
                return BadRequest("No AssetHistory with id: " + id);

            var result = await _assetHistoryService.ReadAsync(id);

            if (!result)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

    }
}
