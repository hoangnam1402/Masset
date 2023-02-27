using Business.Interfaces;
using Contracts.Dtos;
using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.EmployeeDtos;
using Contracts.Dtos.MaintenanceDtos;
using DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAssetService _assetService;
        private readonly IMaintenanceService _maintenanceService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IBrandService _brandService;
        private readonly ILocationService _locationService;
        private readonly ISupplierService _supplierService;
        public MobileController(IEmployeeService employeeService, 
            IAssetService assetService, 
            IMaintenanceService maintenanceService,
            IAssetTypeService assetTypeService,
            IBrandService brandService,
            ILocationService locationService,
            ISupplierService supplierService)
        {
            _employeeService = employeeService;
            _assetService=assetService;
            _maintenanceService=maintenanceService;
            _assetTypeService=assetTypeService;
            _brandService=brandService;
            _locationService=locationService;
            _supplierService=supplierService;
        }

        [HttpPost("Login")]
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

            if(emloyee.IsDeleted)
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

        [HttpPut("ChangePassword/{id}")]
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

            if (emloyee.Password != employeeRequest.CurrentPassword)
            {
                var error = "Password is incorrect. Please try again";
                return new EmployeeResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            emloyee.Password = employeeRequest.NewPassword;
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

        [HttpGet("GetAsset/{id}/{tag}")]
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
                Type = asset.Type?.Name,
                Supplier = asset.Supplier?.Name,
                Location = asset.Location?.Name,
                Brand = asset.Brand?.Name,
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

        [HttpPut("UpdateAsset/{id}/{tag}")]
        public async Task<AssetResponseDto> UpdateAsset([FromRoute] Guid id, string tag,
                                                        [FromBody] AssetUpdateDto assetequest)
        {
            if (string.IsNullOrEmpty(assetequest.Name))
            {
                var error = "Asset name is required.";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if ((assetequest.TypeID.HasValue && !await _assetTypeService.IsExist(assetequest.TypeID.Value)) ||
                (assetequest.BrandID.HasValue && !await _brandService.IsExist(assetequest.BrandID.Value)) ||
                (assetequest.LocationID.HasValue && !await _locationService.IsExist(assetequest.LocationID.Value)) ||
                (assetequest.SupplierID.HasValue && !await _supplierService.IsExist(assetequest.SupplierID.Value)))
            {
                var error = "AssetType, Brand, Location or Supplier not exist!!!";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

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

            var asset = await _assetService.UpdateAsync(tag, assetequest);
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
                Type = asset.Type?.Name,
                Supplier = asset.Supplier?.Name,
                Location = asset.Location?.Name,
                Brand = asset.Brand?.Name,
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

        [HttpPost("CreateMaintenance/{id}")]
        public async Task<MaintenanceResponseDto> CreateMaintenance([FromRoute] Guid id,
                                                [FromBody] MaintenanceCreateDto maintenanceequest)
        {
            if (!await _employeeService.IsExist(id))
            {
                var error = "Employee not exist!!!";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (await _employeeService.IsDelete(id))
            {
                var error = "Employee has been deleted!!!";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (maintenanceequest.Type is 0 ||
                maintenanceequest.AssetID is 0)
            {
                var error = "Asset and Type are required.";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _assetService.IsExist(maintenanceequest.AssetID))
            {
                var error = "Asset not exist!!!";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var asset = await _assetService.GetByIdAsync(maintenanceequest.AssetID);
            if (asset == null)
            {
                var error = "Somethink go wrong.";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if ((asset.Status == AssetStatusEnums.OutOfRepair && maintenanceequest.Type == MaintenanceTypeEnums.Repair) ||
                asset.Status == AssetStatusEnums.Lost)
            {
                var error = "Asset was Out Of Repair or Lost";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var maintenance = await _maintenanceService.CreateAsync(maintenanceequest);
            if (maintenance == null)
            {
                var error = "Something go wrong";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            MaintenanceResponseDto result = new MaintenanceResponseDto()
            {
                Id = maintenance.Id,
                Asset = maintenance.Asset?.Name,
                Supplier = maintenance.Supplier?.Name,
                Type = maintenance.Type,
                StartDate = maintenance.StartDate,
                EndDate = maintenance.EndDate,
                Error = false,
                Message = "",
            };

            return result;

        }
    }
}
