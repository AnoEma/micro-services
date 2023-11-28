using Transactional.Worker.BookStore;

namespace Transactional.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ICreateBookStoreCommandHandler _createBookStoreCommandHandler;

    public Worker
    (
        ILogger<Worker> logger,
        ICreateBookStoreCommandHandler createBookStoreCommandHandler)
    {
        _logger = logger;
        _createBookStoreCommandHandler = createBookStoreCommandHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        for (int i = 0; i < 5; i++)
        {
            var events = CreateEvent();
            await _createBookStoreCommandHandler.HandleCreateBookStore(events, stoppingToken);
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