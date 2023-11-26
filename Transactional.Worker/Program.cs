using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using MassTransit;
using Microsoft.Extensions.Options;
using Transactional.Worker;
using Transactional.Worker.MessageBroker;
using Transactional.Worker.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<MessageBrokerSettings>(
    builder.Configuration.GetSection("MessageBroker")
);

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

builder.Services.AddMassTransit(busConfig => {

    busConfig.SetKebabCaseEndpointNameFormatter();

    busConfig.UsingRabbitMq((context, configurator) =>{
        MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

        configurator.Host(new Uri(settings.Host), h =>{
            h.Username(settings.UserName);
            h.Password(settings.Password);
        });

    });
});

builder.Services.AddTransient<ITransactionalService, TransactionlService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();