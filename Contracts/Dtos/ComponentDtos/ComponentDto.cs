using Contracts.Dtos.AssetTypeDtos;
using Contracts.Dtos.BrandsDtos;
using Contracts.Dtos.LocationDtos;
using Contracts.Dtos.SupplierDtos;
using DataAccess.Enums;

namespace Contracts.Dtos.ComponentDtos
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Serial { get; set; }
        public int? Quantity { get; set; }
        public AssetTypeDto? Type { get; set; }
        public SupplierDto? Supplier { get; set; }
        public LocationDto? Location { get; set; }
        public BrandDto? Brand { get; set; }
        public int? TypeID { get; set; }
        public int? SupplierID { get; set; }
        public int? LocationID { get; set; }
        public int? BrandID { get; set; }
        public int? AvailableQuantity { get; set; }
        public int? Cost { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public int? Warranty { get; set; }
        public AssetStatusEnums Status { get; set; }
        public string? Description { get; set; }
    }
}
