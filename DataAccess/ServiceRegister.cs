using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ServiceRegister
    {
        public static void AddDataAccessorLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(config.GetConnectionString("MySqlDbConnection"), b =>
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));
        }
    }
}
