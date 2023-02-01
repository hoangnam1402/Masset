namespace DataAccess.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public Asset? Asset { get; set; }
        public int? AssetID { get; set; }
        public Supplier? Supplier { get; set; }
        public int? SupplierID { get; set; }
        public AssetType? Type { get; set; }
        public int? TypeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
