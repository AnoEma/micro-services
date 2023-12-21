using CustomerService.Api.Model;

namespace CustomerService.Api;

public class CustomerService : ICustomerService
{
    private readonly ILogger<CustomerService> _logger;
    private readonly ICustomerRepository _repository;

    public CustomerService(ILogger<CustomerService> logger, ICustomerRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public Task CreateCustomer(Customers model, CancellationToken cancelllation)
    {
        var result = _repository.Create(model);

        if (!result.IsCompleted)
        {
            _logger.LogInformation("Ocorreu erro ao cadastrar o cliente");
            return Task.FromCanceled(cancelllation);
        }
        return result;
    }

    public async Task<Customers?> GetCustomerById(Guid id, CancellationToken cancelllation)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            _logger.LogInformation("Client não encontrado Id:{id}", id);
            return null;
        }

        return result;
    }
}