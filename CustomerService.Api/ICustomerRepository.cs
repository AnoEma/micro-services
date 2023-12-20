using CustomerService.Api.Model;

namespace CustomerService.Api;

public interface ICustomerRepository
{
    Task Create(Customers dto);
    Task<Customers> GetById(Guid id);
}