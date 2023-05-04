using Business.Interfaces;
using Contracts.Dtos;
using DataAccess.Entities;
using DataAccess.Enums;

namespace Business.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IBaseRepository<Asset> _assetRepository;
        private readonly IBaseRepository<Component> _componentRepository;
        private readonly IBaseRepository<AssetType> _assetTypeRepository;
        private readonly IBaseRepository<Maintenance> _maintenanceRepository;
        private readonly IBaseRepository<User> _userRepository;

        public DashboardService(IBaseRepository<Asset> assetRepository,
            IBaseRepository<Component> componentRepository,
            IBaseRepository<AssetType> assetTypeRepository,
            IBaseRepository<Maintenance> maintenanceRepository,
            IBaseRepository<User> userRepository)
        {
            _assetRepository = assetRepository;
            _componentRepository = componentRepository;
            _assetTypeRepository = assetTypeRepository;
            _maintenanceRepository = maintenanceRepository;
            _userRepository = userRepository;
        }

        public async Task<DashboardDto?> GetDashboard()
        {
            var assets = await _assetRepository.GetAll();
            var components = await _componentRepository.GetAll();
            var maintenances = await _maintenanceRepository.GetAll();
            var users = await _userRepository.GetAll();
            var types = await _assetTypeRepository.GetAll();
            var numberOfTypes = types.Where(x => x.IsDeleted == false)
                .GroupBy(x => x.Name)
                .Select(x => new DashboardDto.NumberOfType { Name = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5);

            var dashboard = new DashboardDto();
            dashboard.TotalAsset = assets.Where(x => x.IsDeleted == false).Count();
            dashboard.TotalComponent = components.Where(x => x.IsDeleted == false).Count();
            dashboard.TotalMaintenance = maintenances.Where(x => x.IsDeleted == false).Count();
            dashboard.TotalEmployee = users.Where(x => x.IsActive == true && x.Role == UserRoleEnums.Staff).Count();
            dashboard.NumberOfStatus1 = assets.Where(x => x.IsDeleted == false && x.Status == AssetStatusEnums.ReadyToDeploy).Count();
            dashboard.NumberOfStatus2 = assets.Where(x => x.IsDeleted == false && x.Status == AssetStatusEnums.Pending).Count();
            dashboard.NumberOfStatus3 = assets.Where(x => x.IsDeleted == false && x.Status == AssetStatusEnums.Archived).Count();
            dashboard.NumberOfStatus4 = assets.Where(x => x.IsDeleted == false && x.Status == AssetStatusEnums.Broken).Count();
            dashboard.NumberOfStatus5 = assets.Where(x => x.IsDeleted == false && x.Status == AssetStatusEnums.Lost).Count();
            dashboard.NumberOfStatus6 = assets.Where(x => x.IsDeleted == false && x.Status == AssetStatusEnums.OutOfRepair).Count();
            foreach (var item in numberOfTypes)
            {
                dashboard.NumberOfTypes.Add(item);
            }

            return dashboard;
        }
    }
}
