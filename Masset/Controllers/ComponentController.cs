using Business.Interfaces;
using Contracts;
using Contracts.Dtos.ComponentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IBrandService _brandService;
        private readonly ILocationService _locationService;
        private readonly ISupplierService _supplierService;
        public ComponentController(IComponentService componentService, 
            IAssetTypeService assetTypeService,
            IBrandService brandService,
            ILocationService locationService,
            ISupplierService supplierService)
        {
            _componentService = componentService;
            _assetTypeService=assetTypeService;
            _brandService=brandService;
            _locationService=locationService;
            _supplierService=supplierService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByPage([FromQuery] BaseQueryCriteria queryCriteria,
                                                               CancellationToken cancellationToken)
        {
            var responses = await _componentService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ComponentCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name) ||
                string.IsNullOrEmpty(createDto.Serial) ||
                createDto.Warranty is 0 ||
                createDto.Cost is 0)
                return BadRequest("Component name, serial, warranty and cost are required.");
            if (await _componentService.IsExist(createDto.Name))
                return BadRequest("Component name has been used before!!!");
            if (createDto.TypeID.HasValue && !await _assetTypeService.IsExist(createDto.TypeID.Value))
                return BadRequest("AssetType not exist!!!");
            if (createDto.BrandID.HasValue && !await _brandService.IsExist(createDto.BrandID.Value))
                return BadRequest("Brand not exist!!!");
            if (createDto.LocationID.HasValue && !await _locationService.IsExist(createDto.LocationID.Value))
                return BadRequest("Location not exist!!!");
            if (createDto.SupplierID.HasValue && !await _supplierService.IsExist(createDto.SupplierID.Value))
                return BadRequest("Supplier not exist!!!");

            var result = await _componentService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] ComponentUpdateDto updateDTO)
        {
            if (string.IsNullOrEmpty(updateDTO.Name))
                return BadRequest("Component name is required.");
            if (!await _componentService.IsExist(id))
                return BadRequest("Component not exist!!!");
            if (updateDTO.TypeID.HasValue && !await _assetTypeService.IsExist(updateDTO.TypeID.Value))
                return BadRequest("AssetType not exist!!!");
            if (updateDTO.BrandID.HasValue && !await _brandService.IsExist(updateDTO.BrandID.Value))
                return BadRequest("Brand not exist!!!");
            if (updateDTO.LocationID.HasValue && !await _locationService.IsExist(updateDTO.LocationID.Value))
                return BadRequest("Location not exist!!!");
            if (updateDTO.SupplierID.HasValue && !await _supplierService.IsExist(updateDTO.SupplierID.Value))
                return BadRequest("Supplier not exist!!!");

            var result = await _componentService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _componentService.IsExist(id))
                return BadRequest("Component not exist!!!");
            if (await _componentService.IsDelete(id))
                return BadRequest("Component has been deleted before.");

            var result = await _componentService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _componentService.IsExist(id))
                return BadRequest("Not Component with id: " + id);

            var result = await _componentService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Not Found !");
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _componentService.GetAll();
            return Ok(result);
        }

    }
}
