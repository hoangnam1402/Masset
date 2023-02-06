﻿using Business.Interfaces;
using Contracts.Dtos.EmployeeDtos;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<EmployeeResponseDto> CreateEmployee([FromBody] EmployeeCreateDto employeeDto)
        {
            if (string.IsNullOrEmpty(employeeDto.UserName) || string.IsNullOrEmpty(employeeDto.Password))
            {
                var error = "Username and password is required.";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var e = await _employeeService.CreateEmployee(employeeDto);

            if (e == null)
            {
                var error = "Username exist. Please try again";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            EmployeeResponseDto result = new EmployeeResponseDto()
            {
                Id = e.Id,
                UserName = e.UserName,
                Email = e.Email,
                Phone = e.Phone,
                JobRole = e.JobRole,
                DepartmentID = e.DepartmentID,
                Address = e.Address,
                Error = false,
                Message = "",
            };
            return result;
        }

    }
}