using Business.Interfaces;
using Contracts;
using Contracts.Dtos.CheckingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly ICheckingService _checkingService;
        private readonly IComponentService _componentService;
        public CheckingController(IAssetService assetService, ICheckingService checkingService, IComponentService componentService)
        {
            _assetService = assetService;
            _checkingService = checkingService;
            _componentService = componentService;
        }

        [HttpPost("checkOutAsset")]
        [Authorize]
        public async Task<IActionResult> CreateForAsset([FromBody] CheckingCreateDto createDTO)
        {
            if (createDTO.AssetID is null)
                return BadRequest("AssetID is requested");
            if (!await _assetService.IsExist((int)createDTO.AssetID))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete((int)createDTO.AssetID))
                return BadRequest("Asset have been delete!!!");
            var responses = await _assetService.UpdateCheckingAsync((int)createDTO.AssetID);
            if (!responses)
                return BadRequest("Somethink go wrong.");

            var result = await _checkingService.CreateAsync(createDTO);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("checkInAsset")]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] CheckingUpdateDto updateDTO)
        {
            if (updateDTO.AssetID is null)
                return BadRequest("AssetID is requested");
            if (!await _assetService.IsExist((int)updateDTO.AssetID))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete((int)updateDTO.AssetID))
                return BadRequest("Asset have been delete!!!");
            var responses = await _assetService.UpdateCheckingAsync((int)updateDTO.AssetID);
            if (!responses)
                return BadRequest("Somethink go wrong.");

            var result = await _checkingService.DeleteAsync(updateDTO);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPost("historyOfAsset/{id}")]
        [Authorize]
        public async Task<IActionResult> History([FromRoute] int id,
                                                [FromBody] BaseQueryCriteria queryCriteria,
                                                           CancellationToken cancellationToken)
        {
            if (!await _assetService.IsExist(id))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete(id))
                return BadRequest("Asset have been delete!!!");

            var result = await _checkingService.GetHistoryOfAssetAsync(queryCriteria, cancellationToken,id);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPost("componentOfAsset/{id}")]
        [Authorize]
        public async Task<IActionResult> ComponentOfAsset([FromRoute] int id,
                                                          [FromBody] BaseQueryCriteria queryCriteria,
                                                                     CancellationToken cancellationToken)
        {
            if (!await _assetService.IsExist(id))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete(id))
                return BadRequest("Asset have been delete!!!");

            var result = await _checkingService.GetByAssetOfComponentAsync(queryCriteria, cancellationToken, id);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPost("checkOutComponent")]
        [Authorize]
        public async Task<IActionResult> CreateForComponent([FromBody] CheckingCreateDto createDTO)
        {
            if (createDTO.ComponentID is null)
                return BadRequest("ComponentID is requested");
            if (!await _componentService.IsExist((int)createDTO.ComponentID))
                return BadRequest("Component not exist!!!");
            if (await _componentService.IsDelete((int)createDTO.ComponentID))
                return BadRequest("Component have been delete!!!");
            if (createDTO.AssetID is null)
                return BadRequest("AssetID is requested");
            if (!await _assetService.IsExist((int)createDTO.AssetID))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete((int)createDTO.AssetID))
                return BadRequest("Asset have been delete!!!");
            var responses = await _componentService.UpdateAsync((int)createDTO.ComponentID, createDTO.Quantity, true);
            if (!responses)
                return BadRequest("Somethink go wrong.");

            var result = await _checkingService.CreateAsync(createDTO);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("checkInComponent/{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] CheckingUpdateDto updateDTO)
        {
            if (updateDTO.ComponentID is null)
                return BadRequest("ComponentID is requested");
            if (!await _componentService.IsExist((int)updateDTO.ComponentID))
                return BadRequest("Component not exist!!!");
            if (await _componentService.IsDelete((int)updateDTO.ComponentID))
                return BadRequest("Component have been delete!!!");
            if (updateDTO.AssetID is null)
                return BadRequest("AssetID is requested");
            if (!await _assetService.IsExist((int)updateDTO.AssetID))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete((int)updateDTO.AssetID))
                return BadRequest("Asset have been delete!!!");
            var responses = await _componentService.UpdateAsync((int)updateDTO.ComponentID, updateDTO.Quantity, false);
            if (!responses)
                return BadRequest("Somethink go wrong.");

            var result = await _checkingService.UpdateAsync(id, updateDTO);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPost("activeOfComponent/{id}")]
        [Authorize]
        public async Task<IActionResult> ActiveOfComponent([FromRoute] int id,
                                                           [FromBody] BaseQueryCriteria queryCriteria,
                                                                      CancellationToken cancellationToken)
        {
            if (!await _componentService.IsExist(id))
                return BadRequest("Component not exist!!!");
            if (await _componentService.IsDelete(id))
                return BadRequest("Component have been delete!!!");

            var result = await _checkingService.GetByComponentAsync(queryCriteria, cancellationToken, id);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }
    }
}
