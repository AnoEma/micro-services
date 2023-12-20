using CustomerService.Api.Data;
using CustomerService.Api.Model;

namespace CustomerService.Api;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _context;

    public CustomerRepository(CustomerContext context)
    {
        _context = context;
    }

    public async Task Create(Customers dto)
    {
        _context.Customers.Add(dto);
        _context.SaveChanges();
    }

    public Task<Customers> GetById(Guid id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(customer);
    }
}