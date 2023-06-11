using DataAccess.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.AssetDtos
{
    public class MobileAssetUpdateDto
    {
        [EnumDataType(typeof(AssetStatusEnums))]
        public AssetStatusEnums Status { get; set; }
        public string? Description { get; set; }
    }
}
