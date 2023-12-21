using CustomerService.Api.Model;

namespace CustomerService.Api;

public interface ICustomerService
{
    Task CreateCustomer(Customers model, CancellationToken cancellation);
    Task DeleteCustomer(Guid customerId, CancellationToken cancellation);
    Task<Customers?> GetCustomerById(Guid customerId, CancellationToken cancellation);
    Task<List<Customers>> GetCustomers(CancellationToken cancellation);
    Task UpdateCustomer(Customers model, CancellationToken cancellation);
}