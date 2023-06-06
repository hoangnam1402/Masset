namespace DataAccess.Entities
{
    public class Checking
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public string? UserID { get; set; }
        public int? Quantity { get; set; }
        public Asset? Asset { get; set; }
        public int? AssetID { get; set; }
        public Component? Component { get; set; }
        public int? ComponentID { get; set; }
        public DateTime? CheckDay { get; set; }
        public bool IsCheckOut { get; set; }
        public bool IsEffective { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
    }
}
