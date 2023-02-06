using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.Seeds
{
    public class DefaultEmployee : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee() { Id = Guid.NewGuid(), UserName = "staff", Password = "staff" }
            );
        }

    }
}
