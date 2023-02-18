using Business.Interfaces;
using Contracts.Dtos;
using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAssetService _assetService;
        public MobileController(IEmployeeService employeeService, IAssetService assetService)
        {
            _employeeService = employeeService;
            _assetService=assetService;
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

            if(emloyee.isDeleted)
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

        [HttpPut("{id}")]
        public async Task<EmployeeResponseDto> ChangePassword([FromRoute] Guid id, 
                                                            [FromBody] ChangePasswordDto employeeRequest)
        {
            if (!await _employeeService.IsExist(id))
            {
                var error = "Employee not exist!!!";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (employeeRequest.CurrentPassword == employeeRequest.NewPassword)
            {
                var error = "The new password cannot be the same as the old password";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (await _employeeService.IsDelete(id))
            {
                var error = "Employee has been deleted!!!";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var emloyee = await _employeeService.GetByIdAsync(id);

            if (emloyee == null)
            {
                var error = "Something go wrong.";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (emloyee.Password == employeeRequest.CurrentPassword)
            {
                var error = "Password is incorrect. Please try again";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var changePasswordSuccess = await _employeeService.ChangePassword(id, emloyee);
            if(!changePasswordSuccess)
            {
                var error = "Something go wrong";
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

        [HttpGet("{id}/{tag}")]
        public async Task<AssetResponseDto> GetAsset([FromRoute] Guid id, string tag)
        {
            if (!await _employeeService.IsExist(id) || !await _assetService.IsExist(tag))
            {
                var error = "Employee or Asset not exist!!!";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (await _employeeService.IsDelete(id) || await _assetService.IsDelete(tag))
            {
                var error = "Employee or Asset has been deleted!!!";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var asset = await _assetService.GetByTagAsync(tag);
            if (asset == null)
            {
                var error = "Something go wrong";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            AssetResponseDto result = new AssetResponseDto()
            {
                Id = asset.Id,
                Name = asset.Name,
                Tag = asset.Tag,
                Type = asset.Type == null ? null : asset.Type.Name,
                Supplier = asset.Supplier == null ? null :  asset.Supplier.Name,
                Location = asset.Location == null ? null :  asset.Location.Name,
                Brand = asset.Brand == null ? null :  asset.Brand.Name,
                Serial = asset.Serial,
                Cost = asset.Cost,
                Warranty = asset.Warranty,
                Status = asset.Status,
                Description = asset.Description,
                CreateDay = asset.CreateDay,
                UpdateDay = asset.UpdateDay,
                Error = false,
                Message = "",
            };

            return result;
        }
    }
}
