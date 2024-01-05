using Serializations;
using Transactional.Worker.BookStore;
using Transactional.Worker.Client;
using Transactional.Worker.Event;
using Transactional.Worker.Services;

namespace Transactional.Worker;

public static class WorkerModuleDependency
{
    public static void AddModule(this IServiceCollection services)
    {
        AddInfraModule(services);
        AddRabbitModule(services);
    }

    private static void AddRabbitModule(IServiceCollection services)
    {
        services.AddSingleton<IRabbitMQSettings, RabbitMQSettings>();
    }

    private static void AddInfraModule(IServiceCollection services)
    {
        services.AddScoped<ICreateBookStoreCommandHandler, CreateBookStoreCommandHandler>();
        services.AddScoped<IBookStoreCreatedEventConsumer, BookStoreCreatedEventConsumer>();
        services.AddScoped<IBookStoreCreatedEventConsumer, BookStoreCreatedEventConsumer>();
        services.AddScoped<IBookStoreHttp, BookStoreHttp>();
        

        services.AddScoped<IBookstoreProcessingService, BookstoreProcessingService>();

        services.AddScoped<IEventBus, EventBus>();
        services.AddScoped<ISerializationObject, SerializationObject>();
    }
}