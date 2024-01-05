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

    public async Task Create(Customers dto, CancellationToken cancelllation)
    {
        _context.Add(dto);
        _context.SaveChanges();
    }

    public async Task Delete(Guid id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

        _context.Remove(customer);
        _context.SaveChanges();
    }

    public Task<Customers> GetById(Guid id, CancellationToken cancellation)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(customer);
    }

    public Task<List<Customers>> GetAll(CancellationToken cancellation)
    {
        var customer = _context.Customers.ToList();
        return Task.FromResult(customer);
    }

    public async Task Update(Customers dto, CancellationToken cancellation)
    {
        _context.Customers.Update(dto);
        _context.SaveChanges();
    }
}