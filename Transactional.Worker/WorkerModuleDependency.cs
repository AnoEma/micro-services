using Transactional.Worker.BookStore;
using Transactional.Worker.Event;

namespace Transactional.Worker;

public static class WorkerModuleDependency
{
    public static void AddModule(this IServiceCollection services)
    {
        AddInfraModule(services);
    }

    private static void AddInfraModule(IServiceCollection services)
    {
        services.AddTransient<ICreateBookStoreCommandHandler, CreateBookStoreCommandHandler>();
        services.AddTransient<IBookStoreCreatedEventConsumer, BookStoreCreatedEventConsumer>();
        
        services.AddTransient<IEventBus, EventBus>();
    }
}