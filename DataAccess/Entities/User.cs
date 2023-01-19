using DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Phone { get; set; }

        [Required]
        public UserTypeEnum Role { get; set; }

        public string? Status { get; set; }
    }
}
