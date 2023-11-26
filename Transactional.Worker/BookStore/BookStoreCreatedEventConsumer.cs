using MassTransit;

namespace Transactional.Worker.BookStore;

public sealed class BookStoreCreatedEventConsumer : IConsumer<BookStoreEvent>
{
    private readonly ILogger<BookStoreCreatedEventConsumer> _logger;

    public BookStoreCreatedEventConsumer(ILogger<BookStoreCreatedEventConsumer> logger)
    {
        _logger = logger;
    }
    Task IConsumer<BookStoreEvent>.Consume(ConsumeContext<BookStoreEvent> context)
    {
        _logger.LogInformation($"Event Bookstore {context.Message}");

        return Task.CompletedTask;
    }
}