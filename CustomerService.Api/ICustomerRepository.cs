using CustomerService.Api.Model;

namespace CustomerService.Api;

public interface ICustomerRepository
{
    Task Create(Customers dto);
    Task Delete(Guid id);
    Task<Customers> GetById(Guid id);
    Task<List<Customers>> GetAll();
    Task Update(Customers dto);
}