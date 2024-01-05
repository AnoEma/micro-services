using Transactional.Worker.BookStore;
using Transactional.Worker.Client;

namespace Transactional.Worker.Services;

public class BookstoreProcessingService : IBookstoreProcessingService
{
    private readonly ILogger<BookstoreProcessingService> _logger;
    private readonly IBookStoreCreatedEventConsumer _createdEventConsumer;
    private readonly ICreateBookStoreCommandHandler _createBookStoreCommandHandler;
    private readonly IBookStoreHttp _serviceHttp;

    public BookstoreProcessingService
    (
        ILogger<BookstoreProcessingService> logger,
        IBookStoreCreatedEventConsumer createdEventConsumer,
        ICreateBookStoreCommandHandler createBookStoreCommandHandler,
        IBookStoreHttp serviceHttp)
    {
        _logger = logger;
        _createdEventConsumer = createdEventConsumer;
        _createBookStoreCommandHandler = createBookStoreCommandHandler;
        _serviceHttp = serviceHttp;
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Scoped Processing Service is working...");

            //for (int i = 0; i < 10; i++)
            //{
            //    var events = CreateEvent();
            //    _createBookStoreCommandHandler.HandleCreateBookStore(events, stoppingToken); 
            //}

            var bookStore = await _createdEventConsumer.GetBookstore();

            if (bookStore is not null)
            {
                await _serviceHttp.CreateBookstore(bookStore, stoppingToken);
                _logger.LogInformation("Created the bookstore - Id: {id}", bookStore.Id);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }

    private BookStoreEvent CreateEvent()
    {
        return new BookStoreEvent
        {
            Id = Guid.NewGuid(),
            Name = "Casa branca",
            CPF = "994.403.710-99",
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