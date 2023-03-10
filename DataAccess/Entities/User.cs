using DataAccess.Enums;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; } = true;
        public UserRoleEnums Role { get; set; } = UserRoleEnums.Admin;
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
    }
}
