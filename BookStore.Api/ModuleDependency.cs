using BookStore.Api.Data;
using BookStore.Api.Repositories;
using BookStore.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api;

public static class ModuleDependency
{
    public static void AddModule(this IServiceCollection services)
    {
        AddRepositories(services);
        AddServices(services);
        AddDataContext(services);
    }

    private static void AddDataContext(IServiceCollection services)
    {
        services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("Server=localhost,1455;Database=bookstore-api-db;User ID=sa;Password=Admin@123"));
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