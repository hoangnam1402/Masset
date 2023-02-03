using DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class User : IdentityUser<int>
    {
        public UserStatusEnums Status { get; set; }
        public bool NewAccount { get; set; } = true;
    }
}
