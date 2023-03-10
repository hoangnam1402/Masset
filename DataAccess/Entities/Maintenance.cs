using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public Asset? Asset { get; set; }
        public Supplier? Supplier { get; set; }
        public int AssetID { get; set; }
        public int? SupplierID { get; set; }
        public MaintenanceTypeEnums? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool IsDeleted { get; set; }

    }
}
