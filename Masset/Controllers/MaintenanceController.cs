using Business.Interfaces;
using Contracts;
using Contracts.Dtos.MaintenanceDtos;
using DataAccess.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;
        private readonly IAssetService _assetService;
        private readonly ISupplierService _supplierService;
        public MaintenanceController(
            IMaintenanceService maintenanceService, 
            IAssetService assetService,
            ISupplierService supplierService)
        {
            _maintenanceService = maintenanceService;
            _assetService=assetService;
            _supplierService=supplierService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _maintenanceService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] MaintenanceCreateDto createDto)
        {
            if (createDto.Type is 0 ||
                createDto.AssetID is 0 ||
                createDto.SupplierID is 0)
                return BadRequest("Asset, Supplier, Type, StartDate and EndDate are required.");

            if (!await _assetService.IsExist(createDto.AssetID))
                return BadRequest("No Asset with id: " + createDto.AssetID);
            if (!await _supplierService.IsExist(createDto.SupplierID))
                return BadRequest("No Supplier with id: " + createDto.SupplierID);
            var asset = await _assetService.GetByIdAsync(createDto.AssetID);
            if (asset == null)
                return BadRequest("Not Found Asset!");

            if (asset.Status == AssetStatusEnums.OutOfRepair && createDto.Type == MaintenanceTypeEnums.Repair)
                return BadRequest("Asset was Out Of Repair");
            if (asset.Status == AssetStatusEnums.Lost)
                return BadRequest("Asset was Lost");

            var result = await _maintenanceService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] MaintenanceUpdateDto updateDTO)
        {
            if (!await _maintenanceService.IsExist(id))
                return BadRequest("Maintenance not exist!!!");

            var result = await _maintenanceService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _maintenanceService.IsExist(id))
                return BadRequest("Maintenance not exist!!!");
            if (await _maintenanceService.IsDelete(id))
                return BadRequest("Maintenance has been deleted before.");

            var result = await _maintenanceService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _maintenanceService.IsExist(id))
                return BadRequest("Not Maintenance with id: " + id);

            var result = await _maintenanceService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

    }
}
