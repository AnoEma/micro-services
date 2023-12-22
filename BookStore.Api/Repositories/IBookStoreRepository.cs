using BookStore.Api.Model;

namespace BookStore.Api.Repositories;

public interface IBookStoreRepository
{
    Task<List<BookStores>> GetAll();
    Task<BookStores> GetById(Guid id);
    Task Create(BookStores dto);
    Task Update(BookStores dto);
}