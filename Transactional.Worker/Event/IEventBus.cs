namespace Transactional.Worker.Event;

public interface IEventBus
{
    Task consummerAsync();
    Task publishAsync<T>(T message, CancellationToken cancellationToken = default)
    where T: class;
}