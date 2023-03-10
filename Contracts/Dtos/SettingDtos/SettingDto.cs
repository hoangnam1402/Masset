namespace Contracts.Dtos.SettingDtos
{
    public class SettingDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FormatDate { get; set; }
        public string? Currency { get; set; }
        public string? Language { get; set; }
        public byte[]? Logo { get; set; }

    }
}
