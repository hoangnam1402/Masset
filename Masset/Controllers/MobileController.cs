using Business.Interfaces;
using Contracts.Dtos;
using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.MaintenanceDtos;
using Contracts.Dtos.UserDtos;
using DataAccess.Entities;
using DataAccess.Enums;
using Masset.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IAssetService _assetService;
        private readonly IMaintenanceService _maintenanceService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IBrandService _brandService;
        private readonly ILocationService _locationService;
        private readonly ISupplierService _supplierService;
        private readonly ISettingService _settingService;

        public MobileController(IAuthService authService,
            UserManager<User> userManager,
            IAssetService assetService, 
            IMaintenanceService maintenanceService,
            IAssetTypeService assetTypeService,
            IBrandService brandService,
            ILocationService locationService,
            ISupplierService supplierService,
            IUserService userService,
            ISettingService settingService)
        {
            _authService = authService;
            _userManager = userManager;
            _assetService =assetService;
            _maintenanceService=maintenanceService;
            _assetTypeService=assetTypeService;
            _brandService=brandService;
            _locationService=locationService;
            _supplierService=supplierService;
            _userService=userService;
            _settingService=settingService;
        }

        [HttpPost("Login")]
        public async Task<UserResponseDto> Login([FromBody] LoginDto userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.UserName) || string.IsNullOrEmpty(userRequest.Password))
            {
                var error = "Username and password is required.";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _authService.ValidateUser(userRequest))
            {
                var error = "Username or password is incorrect. Please try again";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var user = await _userManager.FindByNameAsync(userRequest.UserName);
            var roles = await _userManager.GetRolesAsync(user);
            var token = await _authService.CreateToken();

            if (!user.IsActive)
            {
                var error = "User is not available. Please contact Admin";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            UserResponseDto result = new UserResponseDto()
            {
                Token = token,
                Id = user.Id,
                UserName = user.UserName,
                Role = roles[0],
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                FirstLogin = user.FirstLogin,
                Error = false,
                Message = "",
            };
            return result;
        }

        [HttpGet("GetAsset/{id}/{tag}")]
        public async Task<AssetResponseDto> GetAsset([FromRoute] string id, string tag)
        {
            if (!await _userService.IsExistById(id) || !await _assetService.IsExist(tag))
            {
                var error = "User or Asset not exist!!!";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _userService.IsActive(id) || await _assetService.IsDelete(tag))
            {
                var error = "User or Asset not available!!!";
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
                Image = asset.Image,
                Error = false,
                Message = "",
            };

            return result;
        }

        [HttpGet("GetSetting/{id}")]
        public async Task<SettingResponseDto> GetSetting([FromRoute] string id)
        {
            if (!await _userService.IsExistById(id))
            {
                var error = "User not exist!!!";
                return new SettingResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _userService.IsActive(id))
            {
                var error = "User not available!!!";
                return new SettingResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var setting = await _settingService.GetAsync();
            if (setting == null)
            {
                var error = "Something go wrong";
                return new SettingResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            SettingResponseDto result = new SettingResponseDto()
            {
                Id = setting.Id,
                Name = setting.Name,
                Address = setting.Address,
                Email = setting.Email,
                Phone = setting.Phone,
                Currency = setting.Currency,
                Image = setting.Image,
                Error = false,
                Message = "",
            };
            return result;
        }

        [HttpPut("UpdateAsset/{id}/{tag}")]
        public async Task<AssetResponseDto> UpdateAsset([FromRoute] string id, string tag,
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

            if ((!await _assetTypeService.IsExist(assetequest.TypeID)) ||
                (!await _brandService.IsExist(assetequest.BrandID)) ||
                (!await _locationService.IsExist(assetequest.LocationID)) ||
                (!await _supplierService.IsExist(assetequest.SupplierID)))
            {
                var error = "AssetType, Brand, Location or Supplier not exist!!!";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _userService.IsExistById(id) || !await _assetService.IsExist(tag))
            {
                var error = "User or Asset not exist!!!";
                return new AssetResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _userService.IsActive(id) || await _assetService.IsDelete(tag))
            {
                var error = "User or Asset not available!!!";
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

        [HttpPut("upload-image/{id}/{tag}")]
        public async Task<AssetResponseDto> UpdateAsset([FromRoute] string id, string tag,
                                                [FromForm] IFormFile image)
        {
            var asset = await _assetService.UpdateImageAsync(tag, image);
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
                Error = false,
                Message = "",
            };

            return result;
        }

        [HttpPost("CreateMaintenance/{id}")]
        public async Task<MaintenanceResponseDto> CreateMaintenance([FromRoute] string id,
                                                [FromBody] MaintenanceCreateDto maintenanceequest)
        {
            if (!await _userService.IsExistById(id))
            {
                var error = "User not exist!!!";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _userService.IsActive(id))
            {
                var error = "User has been deleted!!!";
                return new MaintenanceResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (maintenanceequest.Type is 0 ||
                maintenanceequest.AssetID is 0 ||
                maintenanceequest.SupplierID is 0)
            {
                var error = "Asset, Supplier and Type are required.";
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
