using BookStore.Api.Model;

namespace BookStore.Api.Repositories;

public interface IBookStoreRepository
{
    Task<List<BookStores>> GetAll(CancellationToken cancellation);
    Task<BookStores> GetById(Guid id, CancellationToken cancellation);
    Task Create(BookStores dto, CancellationToken cancellation);
    Task Update(BookStores dto, CancellationToken cancellation);
}