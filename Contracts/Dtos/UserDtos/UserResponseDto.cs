namespace Contracts.Dtos.UserDtos
{
    public class UserResponseDto : BaseResponseDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool FirstLogin { get; set; }
        public string? Token { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public string? Role { get; set; }
    }
}
