using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.ComponentDtos;
using DataAccess.Enums;

namespace Contracts.Dtos.DepreciationDtos
{
    public class DepreciationDto
    {
        public int Id { get; set; }
        public DepreciationCategoryEnums Category { get; set; }
        public AssetDto? Asset { get; set; }
        public ComponentDto? Component { get; set; }
        public int? AssetID { get; set; }
        public int? ComponentID { get; set; }
        public int? Period { get; set; }
        public int? Value { get; set; }
        public bool IsDeleted { get; set; }

    }
}
