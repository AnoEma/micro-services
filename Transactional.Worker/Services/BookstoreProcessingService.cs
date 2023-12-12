using Transactional.Worker.BookStore;

namespace Transactional.Worker.Services;

public class BookstoreProcessingService : IBookstoreProcessingService
{
    private readonly ILogger<BookstoreProcessingService> _logger;
    private readonly IBookStoreCreatedEventConsumer _createdEventConsumer;

    public BookstoreProcessingService
    (
        ILogger<BookstoreProcessingService> logger, 
        IBookStoreCreatedEventConsumer createdEventConsumer
    )
    {
        _logger = logger;
        _createdEventConsumer = createdEventConsumer;
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Scoped Processing Service is working. Count");

            var bookStore = _createdEventConsumer.GetBookstore();

            if( bookStore is not null )
            {

            }
            await Task.Delay(10000, stoppingToken);
        }
    }
}