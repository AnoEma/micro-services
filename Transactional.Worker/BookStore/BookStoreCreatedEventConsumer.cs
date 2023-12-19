using Transactional.Worker.Event;

namespace Transactional.Worker.BookStore;

public sealed class BookStoreCreatedEventConsumer : IBookStoreCreatedEventConsumer
{
    private readonly ILogger<BookStoreCreatedEventConsumer> _logger;
    private readonly IEventBus _bus;

    public BookStoreCreatedEventConsumer(ILogger<BookStoreCreatedEventConsumer> logger, IEventBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    public Task<BookStoreEvent> GetBookstore()
    {
        var message = _bus.consummerAsync<BookStoreEvent>();
        return message;
    }
}