using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Seeds
{
    public static class AdminAndRole
    {
        public static void SeedAdminAndRole(this ModelBuilder builer)
        {
            //Seed Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var managerRole = new IdentityRole("Manager");
            managerRole.NormalizedName = managerRole.Name.ToUpper();

            var staffRole = new IdentityRole("Staff");
            staffRole.NormalizedName = staffRole.Name.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                adminRole,
                managerRole,
                staffRole
            };

            builer.Entity<IdentityRole>().HasData(roles);

            //Seed User
            var pwd = "abc123";
            var passwordHasher = new PasswordHasher<User>();
            var admin = new User();
            admin.UserName = "Test";
            admin.NormalizedUserName = admin.UserName.ToUpper();
            admin.IsActive = true;
            admin.Role = Enums.UserRoleEnums.Admin;
            admin.CreateDay = DateTime.Now;
            admin.UpdateDay = DateTime.Now;
            admin.PasswordHash = passwordHasher.HashPassword(admin, pwd);

            builer.Entity<User>().HasData(admin);

            //Seed UserRole
            var userRole = new IdentityUserRole<string>
            {
                UserId = admin.Id,
                RoleId = roles.First(x => x.Name == "Admin").Id
            };

            builer.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}
