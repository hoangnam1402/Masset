namespace DataAccess.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public AssetType Type { get; set; }
        public Supplier Supplier { get; set; }
    }
}
