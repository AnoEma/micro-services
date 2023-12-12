using RabbitMQ.Client;

namespace Transactional.Worker.Client;

public class RabbitMQSettings : IRabbitMQSettings
{
    public IModel Create()
    {
        return ConfigRabbit();
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
        var channel = conn.CreateModel();

        channel.QueueDeclare(
            queue: "bookstore.event.queue",
            durable: true,
            exclusive: false,
            autoDelete: false);

        return channel;
    }
}

public interface IRabbitMQSettings
{
    IModel Create();
}