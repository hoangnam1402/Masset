using DataAccess.Enums;
using Microsoft.AspNetCore.Http;

namespace Contracts.Dtos.AssetDtos
{
    public class AssetResponseDto : BaseResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Tag { get; set; }
        public string? Type { get; set; }
        public string? Supplier { get; set; }
        public string? Location { get; set; }
        public string? Brand { get; set; }
        public string? Serial { get; set; }
        public int? Cost { get; set; }
        public int? Warranty { get; set; }
        public AssetStatusEnums Status { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public DateTime? PurchaseDay { get; set; }
        public bool IsCheckOut { get; set; }
        public IFormFile? Image { get; set; }
    }
}
