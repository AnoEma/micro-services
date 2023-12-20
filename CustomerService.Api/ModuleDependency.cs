
using CustomerService.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Api;

public static class ModuleDependency
{
    public static void AddModule(this IServiceCollection services)
    {
        AddService(services);
        AddRepository(services);
        AddContext(services);
    }

    private static void AddService(IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
    }

    private static void AddContext(IServiceCollection services)
    {
        services.AddDbContext<CustomerContext>(opt => 
        opt.UseSqlServer("Server=localhost,1455;Database=bookstore-api-db;User ID=sa;Password=Admin@123"));
    }
}