using Contracts.Dtos.AssetTypeDtos;
using Contracts.Dtos.BrandsDtos;
using Contracts.Dtos.LocationDtos;
using Contracts.Dtos.SupplierDtos;
using DataAccess.Enums;

namespace Contracts.Dtos.ComponentDtos
{
    public class ComponentResponseDto : BaseResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Serial { get; set; }
        public int? Quantity { get; set; }
        public string? Type { get; set; }
        public string? Supplier { get; set; }
        public string? Location { get; set; }
        public string? Brand { get; set; }
        public int? AvailableQuantity { get; set; }
        public int? Cost { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public int? Warranty { get; set; }
        public AssetStatusEnums Status { get; set; }
        public string? Description { get; set; }
        public DateTime? PurchaseDay { get; set; }
    }
}
