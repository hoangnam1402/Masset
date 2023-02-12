using Business.Interfaces;
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

            if (await _employeeService.LoginFail(employeeLoginDto))
            {
                var error = "Username or password is incorrect. Please try again";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var e = await _employeeService.LoginEmployee(employeeLoginDto);

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
