using Business.Interfaces;
using Contracts.Dtos;
using Contracts.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public MobileController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<EmployeeResponseDto> Login([FromBody] LoginDto employeeLoginDto)
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

            if (await _employeeService.LoginFail(employeeLoginDto))
            {
                var error = "Username or password is incorrect. Please try again";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var emloyee = await _employeeService.LoginEmployee(employeeLoginDto);

            if(emloyee.isDelete)
            {
                var error = "Employee is not available. Please contact admin";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            EmployeeResponseDto result = new EmployeeResponseDto()
            {
                Id = emloyee.Id,
                UserName = emloyee.UserName,
                Email = emloyee.Email,
                Phone = emloyee.Phone,
                JobRole = emloyee.JobRole,
                DepartmentID = emloyee.DepartmentID,
                Address = emloyee.Address,
                Error = false,
                Message = "",
            };
            return result;
        }
    }
}
