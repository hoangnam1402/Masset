using DataAccess.Enums;

namespace Contracts.Dtos.UserDtos
{
    public class UserResponseDto : BaseResponseDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string? Token { get; set; }
    }
}
