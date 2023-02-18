using DataAccess.Enums;

namespace Contracts.Dtos.AssetDtos
{
    public class AssetUpdateDto
    {
        public string? Name { get; set; }
        public string? Tag { get; set; }
        public int? TypeID { get; set; }
        public int? SupplierID { get; set; }
        public int? LocationID { get; set; }
        public int? BrandID { get; set; }
        public int? Cost { get; set; }
        public int? Warranty { get; set; }
        public string? Serial { get; set; }
        public AssetStatusEnums Status { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
