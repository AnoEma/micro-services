using Customer.Api.Model;

namespace Customer.Api.Services;

public interface ICustomerService
{
    Task<Customers> GetCustomersAsync();
}