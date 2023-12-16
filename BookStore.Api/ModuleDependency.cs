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
        services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase(""));
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IBookStoreService, BookStoreService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IBookStoreRepository, IBookStoreRepository>();
    }
}