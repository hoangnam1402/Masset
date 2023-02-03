using Business.Interfaces;
using Contracts.Dtos.EmployeeDtos;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        [HttpPost]
        public async Task<EmployeeResponseDto> Login([FromBody] EmployeeLoginDto employeeLoginDto)
        {
            if (string.IsNullOrEmpty(employeeLoginDto.UserName) || string.IsNullOrEmpty(employeeLoginDto.Password))
            {
                var error = "Username and password is required.";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var e = await _employeeService.LoginEmployee(employeeLoginDto);

            if (await _employeeService.LoginEmployee(employeeLoginDto) != null)
            {
                var error = "Username or password is incorrect. Please try again";
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
