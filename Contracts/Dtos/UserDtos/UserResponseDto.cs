using DataAccess.Enums;

namespace Contracts.Dtos.UserDtos
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool Error { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}
