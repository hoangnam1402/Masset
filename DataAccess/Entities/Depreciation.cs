using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class Depreciation
    {
        public int Id { get; set; }
        public DepreciationCategoryEnums Category { get; set; }
        public Asset? Asset { get; set; }
        public Component? Component { get; set; }
        public int? AssetID { get; set; }
        public int? ComponentID { get; set; }
        public int? Period { get; set; }
        public int? Value { get; set; }
        public bool IsDeleted { get; set; }

    }
}
