using Customer.Api.Model;

namespace Customer.Api.Services;

public class CustomerService : ICustomerService
{
    private Customers customer;
    public CustomerService()
    {
        customer = new Customers
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Email = "Test@gmail.com",
            Phone = "119000000"
        };
    }
    public Task<Customers> GetCustomersAsync()
    {
        return Task.FromResult(customer);
    }
}