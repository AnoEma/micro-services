using Microsoft.Extensions.Options;
using Transactional.Worker;
using Transactional.Worker.MessageBroker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<MessageBrokerSettings>(
    builder.Configuration.GetSection("MessageBroker")
);

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

builder.Services.AddModule();
builder.Services.AddHostedService<Worker>();


var host = builder.Build();
host.Run();