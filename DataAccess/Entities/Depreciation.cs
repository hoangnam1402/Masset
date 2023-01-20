using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class Depreciation
    {
        public int Id { get; set; }
        public DepreciationCategoryEnums Category { get; set; }
        public string? Period { get; set; }
        public int? Value { get; set; }
    }
}
