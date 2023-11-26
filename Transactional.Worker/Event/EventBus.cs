using MassTransit;

namespace Transactional.Worker.Event;

public sealed class EventBus : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventBus(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public Task publishAsync<T>(T message, CancellationToken cancellationToken = default)
    where T : class =>
        _publishEndpoint.Publish(message, cancellationToken);
}