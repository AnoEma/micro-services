using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Transactional.Worker.Event;

public sealed class EventBus : IEventBus
{
    private IModel _publishEndpoint;

    public EventBus()
    {
        ConfigRabbit();
    }

    public Task consummerAsync()
    {
        var result = _publishEndpoint.BasicGet(queue : "bookstore.event.queue", true);
        
        if(result is null)
        {
            return Task.CompletedTask;
        }

        var properties = result.BasicProperties;
        var body = result.Body;

        return Task.CompletedTask;
    }

    public Task publishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        var jsonString = JsonSerializer.Serialize(message);
        byte[] messageBodyBytes = Encoding.UTF8.GetBytes(jsonString);

        _publishEndpoint.BasicPublish("bookstore.event.exchange", "bookstore.event.routingkey", body: messageBodyBytes);

        return Task.CompletedTask;
    }

    private IModel ConfigRabbit()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            VirtualHost = "/"
        };

        var conn = factory.CreateConnection();
        _publishEndpoint = conn.CreateModel();
        _publishEndpoint.QueueDeclare(
            queue: "bookstore.event.queue", 
            durable: true, 
            exclusive: false, 
            autoDelete: false);

        return _publishEndpoint;
    }
}