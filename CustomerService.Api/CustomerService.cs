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
        var result = _repository.Create(model, cancelllation);

        if (!result.IsCompleted)
        {
            _logger.LogInformation("Ocorreu erro ao cadastrar o cliente");
            return Task.FromCanceled(cancelllation);
        }
        return result;
    }

    public async Task DeleteCustomer(Guid customerId, CancellationToken cancellation)
    {
        await _repository.Delete(customerId);
    }

    public async Task<Customers?> GetCustomerById(Guid id, CancellationToken cancellation)
    {
        var result = await _repository.GetById(id, cancellation);

        if (result is null)
        {
            _logger.LogInformation("Client não encontrado Id:{id}", id);
            return null;
        }

        return result;
    }

    public async Task<List<Customers>> GetCustomers(CancellationToken cancellation)
    {
        var result = await _repository.GetAll(cancellation);
        return result;
    }

    public async Task UpdateCustomer(Customers model, CancellationToken cancellation)
    {
        var customer = await _repository.GetById(model.Id, cancellation);

        if (customer is not null)
        {
            await _repository.Update(model, cancellation);
        }
    }
}