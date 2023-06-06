using DataAccess.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.AssetDtos
{
    public class AssetUpdateDto
    {
        public string? Name { get; set; }
        public int TypeID { get; set; }
        public int SupplierID { get; set; }
        public int LocationID { get; set; }
        public int BrandID { get; set; }
        [EnumDataType(typeof(AssetStatusEnums))]
        public AssetStatusEnums Status { get; set; }
        public string? Description { get; set; }
    }
}
