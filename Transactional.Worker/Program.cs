using MassTransit;
using Microsoft.Extensions.Options;
using Transactional.Worker;
using Transactional.Worker.BookStore;
using Transactional.Worker.Event;
using Transactional.Worker.MessageBroker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<MessageBrokerSettings>(
    builder.Configuration.GetSection("MessageBroker")
);

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

builder.Services.AddMassTransit(busConfig =>
{

    busConfig.SetKebabCaseEndpointNameFormatter();
    busConfig.AddConsumer<BookStoreCreatedEventConsumer>();

    busConfig.UsingRabbitMq((context, configurator) =>
    {
        MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

        configurator.Host(new Uri(settings.Host), h =>
        {
            h.Username(settings.UserName);
            h.Password(settings.Password);
        });

    });
});

builder.Services.AddTransient<ICreateBookStoreCommandHandler, CreateBookStoreCommandHandler>();
builder.Services.AddTransient<IEventBus, EventBus>();
builder.Services.AddHostedService<Worker>();


var host = builder.Build();
host.Run();