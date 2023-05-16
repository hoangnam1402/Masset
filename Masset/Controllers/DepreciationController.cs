using Business.Interfaces;
using Contracts;
using Contracts.Dtos.DepreciationDtos;
using DataAccess.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepreciationController : ControllerBase
    {
        private readonly IDepreciationService _depreciationService;
        private readonly IAssetService _assetService;
        private readonly IComponentService _componentService;
        public DepreciationController(IDepreciationService depreciationService, 
                                    IAssetService assetService, 
                                    IComponentService componentService)
        {
            _depreciationService = depreciationService;
            _assetService=assetService;
            _componentService=componentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _depreciationService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] DepreciationCreateDto createDto)
        {
            if (createDto.Value is 0 || createDto.Period is 0)
                return BadRequest("Period and Value are required.");
            DepreciationDto? result;

            if (createDto.Category == DepreciationCategoryEnums.Asset)
            {
                if (createDto.AssetID is null or 0)
                    return BadRequest("Asset is required.");
                else
                {
                    if (!await _assetService.IsExist(createDto.AssetID.Value))
                        return BadRequest("No Asset with id: " + createDto.AssetID);
                    result = await _depreciationService.CreateAsync(createDto);
                }
            }
            else
            {
                if (createDto.ComponentID is null or 0)
                    return BadRequest("Component is required.");
                else
                {
                    if (!await _componentService.IsExist(createDto.ComponentID.Value))
                        return BadRequest("No Asset with id: " + createDto.ComponentID);
                    result = await _depreciationService.CreateAsync(createDto);
                }
            }

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] DepreciationUpdateDto updateDTO)
        {
            if (!await _depreciationService.IsExist(id))
                return BadRequest("Depreciation not exist!!!");
            if (await _depreciationService.IsDelete(id))
                return BadRequest("Depreciation have been delete!!!");

            var result = await _depreciationService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _depreciationService.IsExist(id))
                return BadRequest("Depreciation not exist!!!");
            if (await _depreciationService.IsDelete(id))
                return BadRequest("Depreciation has been deleted before.");

            var result = await _depreciationService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _depreciationService.IsExist(id))
                return BadRequest("Not Depreciation with id: " + id);
            if (await _depreciationService.IsDelete(id))
                return BadRequest("Depreciation has been deleted.");

            var result = await _depreciationService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

    }
}
