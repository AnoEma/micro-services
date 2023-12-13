using Transactional.Worker.BookStore;

namespace Transactional.Worker.Services;

public class BookstoreProcessingService : IBookstoreProcessingService
{
    private readonly ILogger<BookstoreProcessingService> _logger;
    private readonly IBookStoreCreatedEventConsumer _createdEventConsumer;
    private readonly ICreateBookStoreCommandHandler _createBookStoreCommandHandler;

    public BookstoreProcessingService
    (
        ILogger<BookstoreProcessingService> logger,
        IBookStoreCreatedEventConsumer createdEventConsumer
,
        ICreateBookStoreCommandHandler createBookStoreCommandHandler)
    {
        _logger = logger;
        _createdEventConsumer = createdEventConsumer;
        _createBookStoreCommandHandler = createBookStoreCommandHandler;
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Scoped Processing Service is working. Count");

            for (int i = 0; i < 10; i++)
            {
                var events = CreateEvent();
                _createBookStoreCommandHandler.HandleCreateBookStore(events, stoppingToken); 
            }

            var bookStore = _createdEventConsumer.GetBookstore();

            if (bookStore is not null)
            {

            }
            await Task.Delay(10000, stoppingToken);
        }
    }

    private BookStoreEvent CreateEvent()
    {
        return new BookStoreEvent
        {
            Id = Guid.NewGuid(),
            Name = "Casa branca",
            CPF = "000.000.000-21",
            Address = "Rua Congonhas de sertão",
            Books = new List<Book>(){
                new Book{
                        Id = Guid.NewGuid(),
                        Name = "Harry Potter",
                        Price = 200
                },
                 new Book{
                        Id = Guid.NewGuid(),
                        Name = "God of War",
                        Price = 250
                },
            }
        };
    }
}