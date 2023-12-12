namespace Transactional.Worker.Services;

public interface IBookstoreProcessingService
{
    public Task DoWork(CancellationToken stoppingToken);

}