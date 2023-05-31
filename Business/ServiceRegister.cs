using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAssetService, AssetService>();
            services.AddTransient<IComponentService, ComponentService>();
            services.AddTransient<IMaintenanceService, MaintenanceService>();
            services.AddTransient<IDepreciationService, DepreciationService>();
            services.AddTransient<IAssetTypeService, AssetTypeService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IAssetHistoryService, AssetHistoryService>();
            services.AddTransient<ICheckingService, CheckingService>();
        }
    }
}