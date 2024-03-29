﻿using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.ComponentDtos
{
    public class ComponentUpdateDto
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public int? TypeID { get; set; }
        public int? SupplierID { get; set; }
        public int? LocationID { get; set; }
        public int? BrandID { get; set; }
        public string? Description { get; set; }
        [EnumDataType(typeof(AssetStatusEnums))]
        public AssetStatusEnums Status { get; set; }

    }
}
