namespace DataAccess.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? JobRole { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentID { get; set; }
        public string? Address { get; set; }
    }
}
