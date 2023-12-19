using Transactional.Worker;

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.Configure<MessageBrokerSettings>(
//    builder.Configuration.GetSection("MessageBroker")
//);

//builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

builder.Services.AddModule();
builder.Services.AddHostedService<BookstoreConsumerWorker>();


var host = builder.Build();
host.Run();