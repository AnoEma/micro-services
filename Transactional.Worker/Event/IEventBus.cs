namespace Transactional.Worker.Event;

public interface IEventBus
{
    Task<T> consummerAsync<T>() where T: class;
    Task publishAsync<T>(T message, CancellationToken cancellationToken = default)
    where T: class;
}