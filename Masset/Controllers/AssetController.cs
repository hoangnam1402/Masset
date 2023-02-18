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
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAssets(
        [FromQuery] BaseQueryCriteria queryCriteria,
        CancellationToken cancellationToken)
        {
            var responses = await _assetService.GetByPageAsync(
                                            queryCriteria,
                                            cancellationToken);
            return Ok(responses);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AssetCreateDto assetCreateDto)
        {
            if (string.IsNullOrEmpty(assetCreateDto.Name) || string.IsNullOrEmpty(assetCreateDto.Tag))
                return BadRequest("Asset name and tag is required.");
            if (await _assetService.IsExist(assetCreateDto.Tag))
                return BadRequest("Asset tag is exist!!!");

            var result = await _assetService.CreateAsync(assetCreateDto);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somethink go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] AssetUpdateDto assetUpdateDTO)
        {
            if (string.IsNullOrEmpty(assetUpdateDTO.Name) || string.IsNullOrEmpty(assetUpdateDTO.Tag))
                return BadRequest("Asset name and tag is required.");
            if (!await _assetService.IsExist(id))
                return BadRequest("Asset not exist!!!");
            //if (await _assetService.IsExist(assetUpdateDTO.Tag))
            //    return BadRequest("Asset tag is exist!!!");

            var result = await _assetService.UpdateAsync(id, assetUpdateDTO);
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
    }
}
