using Masset.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Masset.Data.Entities
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Phone { get; set; }

        [Required]
        public UserTypeEnum Role { get; set; }

        public string Status { get; set; }
    }
}
