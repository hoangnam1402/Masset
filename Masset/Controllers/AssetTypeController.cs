using Business.Interfaces;
using Contracts;
using Contracts.Dtos.AssetTypeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypeController : ControllerBase
    {
        private readonly IAssetTypeService _assetTypeService;
        public AssetTypeController(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _assetTypeService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AssetTypeCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name))
                return BadRequest("Name is required.");
            if (await _assetTypeService.IsExist(createDto.Name))
                return BadRequest("AssetType name has been used before!!!");

            var result = await _assetTypeService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] AssetTypeUpdateDto updateDTO)
        {
            if (!await _assetTypeService.IsExist(id))
                return BadRequest("AssetType not exist!!!");
            if (await _assetTypeService.IsDelete(id))
                return BadRequest("AssetType have been delete!!!");

            var result = await _assetTypeService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _assetTypeService.IsExist(id))
                return BadRequest("AssetType not exist!!!");
            if (await _assetTypeService.IsDelete(id))
                return BadRequest("AssetType has been deleted before.");

            var result = await _assetTypeService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _assetTypeService.IsExist(id))
                return BadRequest("No AssetType with id: " + id);
            if (await _assetTypeService.IsDelete(id))
                return BadRequest("AssetType have been delete.");

            var result = await _assetTypeService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _assetTypeService.GetAll();
            return Ok(result);
        }

    }
}
