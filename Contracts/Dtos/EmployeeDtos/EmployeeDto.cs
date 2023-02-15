﻿using Contracts.Dtos.DepartmentDtos;

namespace Contracts.Dtos.EmployeeDtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? JobRole { get; set; }
        public DepartmentDto? Department { get; set; }
        public int? DepartmentID { get; set; }
        public string? Address { get; set; }
        public bool isDelete { get; set; }
    }
}
