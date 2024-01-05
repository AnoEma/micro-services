using BookStore.Api.Data;
using BookStore.Api.Repositories;
using BookStore.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api;

public static class ModuleDependency
{
    public static void AddModule(this IServiceCollection services, ConfigurationManager config)
    {
        AddRepositories(services);
        AddServices(services);
        AddDataContext(services, config);
    }

    private static void AddDataContext(IServiceCollection services, ConfigurationManager connection)
    {
        services
            .AddDbContext<BookStoreContext>(opt => 
            opt.UseSqlServer(connection.GetConnectionString("BookstoreDataConnection")));
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddTransient<IBookStoreService, BookStoreService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddTransient<IBookStoreRepository, BookStoreRepository>();
    }
}