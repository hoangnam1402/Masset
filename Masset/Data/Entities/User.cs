using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Masset.Data.Entities
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
