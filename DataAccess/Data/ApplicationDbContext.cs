﻿using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Asset>? Assets { get; set; }
        public DbSet<AssetType>? AssetTypes { get; set; }
        public DbSet<Brands>? Brands { get; set; }
        public DbSet<Component>? Components { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Depreciation>? Depreciations { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<Maintenance>? Maintenances { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName != null && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}