using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.Seeds
{
    public class DefaultSetting : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasData(
                new Setting() 
                { 
                    Id = 1, 
                    Name = "University",
                    Address = "University street",
                    Email = "University@gmail.com",
                    Phone = "123456789",
                    Currency = "USD",
                    Logo = ReadFile("Img/logo.PNG")
                }
            );
        }

        public static byte[] ReadFile(string sPath)
        {
            return File.ReadAllBytes(sPath);
        }
    }
}
