namespace Transactional.Worker.Event;

public interface IEventBus
{
    Task publishAsync<T>(T message, CancellationToken cancellationToken = default)
    where T: class;
}