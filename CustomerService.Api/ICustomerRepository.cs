using CustomerService.Api.Model;

namespace CustomerService.Api;

public interface ICustomerRepository
{
    Task Create(Customers dto, CancellationToken cancelllation);
    Task Delete(Guid id);
    Task<Customers> GetById(Guid id, CancellationToken cancellation);
    Task<List<Customers>> GetAll(CancellationToken cancellation);
    Task Update(Customers dto, CancellationToken cancellation);
}