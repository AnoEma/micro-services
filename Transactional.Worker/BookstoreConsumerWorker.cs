using Transactional.Worker.Services;

namespace Transactional.Worker;

public class BookstoreConsumerWorker : BackgroundService
{
    private readonly ILogger<BookstoreConsumerWorker> _logger;
    private readonly IServiceProvider _service;

    public BookstoreConsumerWorker
    (
        ILogger<BookstoreConsumerWorker> logger,
        IServiceProvider service
    )
    {
        _logger = logger;
        _service = service;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Consume Scoped Service Hosted Service running...");

        await DoWork(stoppingToken);
    }
    private async Task DoWork(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Consume Scoped Service Hosted Service is working...");

        using (var scope = _service.CreateScope())
        {
            var scopedProcessingService =
                scope.ServiceProvider
                    .GetRequiredService<IBookstoreProcessingService>();

            await scopedProcessingService.DoWork(stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Consume Scoped Service Hosted Service is stopping.");

        await base.StopAsync(stoppingToken);
    }
}
