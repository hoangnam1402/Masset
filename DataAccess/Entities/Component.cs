﻿using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class Component
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Serial { get; set; }
        public int? Quantity { get; set; }
        public Supplier? Supplier { get; set; }
        public AssetType? Type { get; set; }
        public Location? Location { get; set; }
        public Brands? Brand { get; set; }
        public int? TypeID { get; set; }
        public int? SupplierID { get; set; }
        public int? LocationID { get; set; }
        public int? BrandID { get; set; }
        public int? Cost { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public int? Warranty { get; set; }
        public AssetStatusEnums Status { get; set; }
        public string? Description { get; set; }
    }
}
