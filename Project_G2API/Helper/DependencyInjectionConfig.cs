using FileManager.DataAccessLayer.DataContext;
using Project_G2.BuissnessAccessLayer.Services;
using Project_G2.BuissnessAccessLayer.Services.IServices;
using Project_G2.DataAccessLayer.Repository;
using Project_G2.DataAccessLayer.Repository.IRepository;

namespace Project_G2API.Helper
{
    public class DependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DapperDBContext>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
