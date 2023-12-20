using CustomerService.Api.Model;

namespace CustomerService.Api;

public interface ICustomerService
{
    Task CreateCustomer(Customers model, CancellationToken cancelllation);
    Task<Customers?> GetCustomerById(Guid id, CancellationToken cancelllation);
}