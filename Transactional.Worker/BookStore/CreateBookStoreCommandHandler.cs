using Transactional.Worker.Event;

namespace Transactional.Worker.BookStore;

public sealed class CreateBookStoreCommandHandler : ICreateBookStoreCommandHandler
{
    private readonly IEventBus _bus;
    public CreateBookStoreCommandHandler(IEventBus bus)
    {
        _bus = bus;
    }

    public async Task HandleCreateBookStore<T>(T events, CancellationToken cancellationToken) 
        where T : class
    {
       await _bus.publishAsync(events, cancellationToken);
    }
}