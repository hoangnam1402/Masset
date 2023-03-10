namespace DataAccess.Entities
{
    public class Brands
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool IsDeleted { get; set; }

    }
}
