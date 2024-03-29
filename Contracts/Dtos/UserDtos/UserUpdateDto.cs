﻿using DataAccess.Enums;

namespace Contracts.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public UserRoleEnums Role { get; set; }

    }
}
