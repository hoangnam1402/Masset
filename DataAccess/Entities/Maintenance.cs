namespace DataAccess.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public Asset? Asset { get; set; }
        public string? AssetId { get; set; }
        public Supplier? Supplier { get; set; }
        public string? SupplierId { get; set; }
        public AssetType? Type { get; set; }
        public string? TypeId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
