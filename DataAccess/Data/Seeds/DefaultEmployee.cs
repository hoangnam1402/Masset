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
                new Employee() { Id = Guid.NewGuid(), UserName = "test1", Password = "test", IsDeleted = false },
                new Employee() { Id = Guid.NewGuid(), UserName = "test2", Password = "test", IsDeleted = true }
            );
        }

    }
}
