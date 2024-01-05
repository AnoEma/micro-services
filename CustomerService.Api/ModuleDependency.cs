
using CustomerService.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Api;

public static class ModuleDependency
{
    public static void AddModule(this IServiceCollection services, ConfigurationManager config)
    {
        AddService(services);
        AddRepository(services);
        AddContext(services, config);
    }

    private static void AddService(IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
    }

    private static void AddContext(IServiceCollection services, ConfigurationManager connectionString)
    {
        services.AddDbContext<CustomerContext>(opt => 
        opt.UseSqlServer(connectionString.GetConnectionString("CustomerDataConnection")));
    }
}