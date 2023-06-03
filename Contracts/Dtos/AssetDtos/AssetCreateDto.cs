using DataAccess.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.AssetDtos
{
    public class AssetCreateDto
    {
        public string? Name { get; set; }
        public string? Tag { get; set; }
        public int TypeID { get; set; }
        public int SupplierID { get; set; }
        public int LocationID { get; set; }
        public int BrandID { get; set; }
        public string? Serial { get; set; }
        public int Cost { get; set; }
        public int Warranty { get; set; }
        public string? Description { get; set; }
        public DateTime? PurchaseDay { get; set; }
        [EnumDataType(typeof(AssetStatusEnums))]
        public AssetStatusEnums Status { get; set; }
        public IFormFile? Image { get; set; }
    }
}
