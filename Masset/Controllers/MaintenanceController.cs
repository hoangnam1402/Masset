﻿using Business.Interfaces;
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
                return BadRequest("Asset, Supplier and Type are required.");

            if (!await _assetService.IsExist(createDto.AssetID))
                return BadRequest("No Asset with id: " + createDto.AssetID);

            var asset = await _assetService.GetByIdAsync(createDto.AssetID);
            if (asset == null)
                return BadRequest("Not Found Asset!");
            if (asset.Status == AssetStatusEnums.OutOfRepair && createDto.Type == MaintenanceTypeEnums.Repair)
                return BadRequest("Asset was Out Of Repair");
            if (asset.Status == AssetStatusEnums.Lost)
                return BadRequest("Asset was Lost");

            if (!await _supplierService.IsExist(createDto.SupplierID))
                return BadRequest("No Supplier with id: " + createDto.AssetID);
            if (await _supplierService.IsDelete(createDto.SupplierID))
                return BadRequest("Supplier have been delete.");

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
            if (await _maintenanceService.IsDelete(id))
                return BadRequest("Maintenance have been delete!!!");

            var result = await _maintenanceService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
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

        [HttpPost("getOfAsset/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOfAssetAsync([FromRoute] int id,
                                                         [FromBody] BaseQueryCriteria queryCriteria,
                                                                    CancellationToken cancellationToken)
        {
            var result = await _maintenanceService.GetOfAssetAsync(queryCriteria, cancellationToken,id);
            return Ok(result);
        }
    }
}
