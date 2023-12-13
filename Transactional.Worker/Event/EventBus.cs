using RabbitMQ.Client;
using Serializations;
using Transactional.Worker.Client;

namespace Transactional.Worker.Event;

public sealed class EventBus : IEventBus
{
    private readonly IRabbitMQSettings _busSettings;
    private readonly ISerializationObject _serializer;

    public EventBus(IRabbitMQSettings busSettings, ISerializationObject serializer)
    {
        _busSettings = busSettings;
        _serializer = serializer;
    }

    public Task<T> consummerAsync<T>() where T : class
    {
        T? message = null;
        var _bus = _busSettings.Create();

        if (_bus is not null)
        {
            var consumer = _bus.BasicGet("bookstore.event.queue", autoAck: true);
            message = _serializer.DeserializerByte<T>(consumer.Body.ToArray());
            return Task.FromResult(message);
        }
        return Task.FromResult(message);
    }

    public Task publishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        var _bus = _busSettings.Create();

        if (_bus is not null)
        {
            var messageBody = _serializer.SerializerByte(message);

            _bus.BasicPublish("bookstore.event.exchange", "bookstore.event.routingkey", body: messageBody);
        }
        return Task.CompletedTask;
    }
}