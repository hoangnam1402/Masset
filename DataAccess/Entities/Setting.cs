namespace DataAccess.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public byte[]? Logo { get; set; }

    }
}
