using Business.Interfaces;
using Contracts;
using Contracts.Dtos.AssetDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IBrandService _brandService;
        private readonly ILocationService _locationService;
        private readonly ISupplierService _supplierService;
        public AssetController(IAssetService assetService, 
            IAssetTypeService assetTypeService,
            IBrandService brandService,
            ILocationService locationService,
            ISupplierService supplierService)
        {
            _assetService = assetService;
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
            var responses = await _assetService.GetByPageAsync(queryCriteria, cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AssetCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name) || 
                string.IsNullOrEmpty(createDto.Tag) ||
                string.IsNullOrEmpty(createDto.Serial) ||
                createDto.Warranty is 0 ||
                createDto.Cost is 0)
                return BadRequest("Asset name, tag, serial, warranty and cost are required.");
            if (await _assetService.IsExist(createDto.Tag))
                return BadRequest("Asset tag has been used before!!!");
            if (createDto.TypeID.HasValue && !await _assetTypeService.IsExist(createDto.TypeID.Value))
                return BadRequest("AssetType not exist!!!");
            if (createDto.BrandID.HasValue && !await _brandService.IsExist(createDto.BrandID.Value))
                return BadRequest("Brand not exist!!!");
            if (createDto.LocationID.HasValue && !await _locationService.IsExist(createDto.LocationID.Value))
                return BadRequest("Location not exist!!!");
            if (createDto.SupplierID.HasValue && !await _supplierService.IsExist(createDto.SupplierID.Value))
                return BadRequest("Supplier not exist!!!");

            var result = await _assetService.CreateAsync(createDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] AssetUpdateDto updateDTO)
        {
            if (string.IsNullOrEmpty(updateDTO.Name))
                return BadRequest("Asset name is required.");
            if (!await _assetService.IsExist(id))
                return BadRequest("Asset not exist!!!");
            if (updateDTO.TypeID.HasValue && !await _assetTypeService.IsExist(updateDTO.TypeID.Value))
                return BadRequest("AssetType not exist!!!");
            if (updateDTO.BrandID.HasValue && !await _brandService.IsExist(updateDTO.BrandID.Value))
                return BadRequest("Brand not exist!!!");
            if (updateDTO.LocationID.HasValue && !await _locationService.IsExist(updateDTO.LocationID.Value))
                return BadRequest("Location not exist!!!");
            if (updateDTO.SupplierID.HasValue && !await _supplierService.IsExist(updateDTO.SupplierID.Value))
                return BadRequest("Supplier not exist!!!");

            var result = await _assetService.UpdateAsync(id, updateDTO);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _assetService.IsExist(id))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete(id))
                return BadRequest("Asset has been deleted before.");

            var result = await _assetService.DeleteAsync(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPost("GeneratingQRCode/{tag}")]
        [Authorize]
        public async Task<IActionResult> GeneratingQRCode([FromRoute] string tag)
        {
            if (!await _assetService.IsExist(tag))
                return BadRequest("Asset not exist!!!");
            if (await _assetService.IsDelete(tag))
                return BadRequest("Asset has been deleted.");

            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData qrCodeData = _qrCode.CreateQrCode(tag, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Image QrBitmap = qrCode.GetGraphic(20);
            MemoryStream qrStream = new MemoryStream();
            QrBitmap.Save(qrStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return File(qrStream.ToArray(), "image/bmp");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!await _assetService.IsExist(id))
                return BadRequest("No Asset with id: " + id);

            var result = await _assetService.GetByIdAsync(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _assetService.GetAll();
            return Ok(result);
        }

    }
}
