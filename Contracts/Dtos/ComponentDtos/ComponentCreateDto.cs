namespace Contracts.Dtos.ComponentDtos
{
    public class ComponentCreateDto
    {
        public string? Name { get; set; }
        public string? Serial { get; set; }
        public int? Quantity { get; set; }
        public int? TypeID { get; set; }
        public int? SupplierID { get; set; }
        public int? LocationID { get; set; }
        public int? BrandID { get; set; }
        public int Cost { get; set; }
        public int Warranty { get; set; }
        public string? Description { get; set; }
        public DateTime? PurchaseDay { get; set; }

    }
}
