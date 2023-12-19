using BookStore.Api.Model;

namespace BookStore.Api.Services;

public interface IBookStoreService
{
    Task<List<BookStores>> GetAll();
    Task<BookStores> GetById(Guid id);
    Task Create(BookStores entity);
    Task Update(BookStores entity);
}