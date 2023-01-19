namespace DataAccess.Entities
{
    public class AssetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual IList<Asset> Assets { get; set; }

        public AssetType()
        {
            Assets =  new List<Asset>();
        }
    }
}
