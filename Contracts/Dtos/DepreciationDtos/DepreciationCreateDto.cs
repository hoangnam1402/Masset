using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.DepreciationDtos
{
    public class DepreciationCreateDto
    {
        [EnumDataType(typeof(DepreciationCategoryEnums))]
        public DepreciationCategoryEnums Category { get; set; }
        public int? AssetID { get; set; }
        public int? ComponentID { get; set; }
        public int Period { get; set; }
        public int Value { get; set; }
    }
}

