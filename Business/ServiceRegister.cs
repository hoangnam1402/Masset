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
            services.AddTransient<IEmployeeService, EmployeeService>();
            //services.AddTransient<IAssetService, AssetService>();
            //services.AddTransient<IAssetCategoryService, AssetCategoryService>();
            //services.AddTransient<IAssignmentService, AssignmentService>();
        }

    }
}