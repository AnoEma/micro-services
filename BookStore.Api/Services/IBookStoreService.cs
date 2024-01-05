using BookStore.Api.Model;

namespace BookStore.Api.Services;

public interface IBookStoreService
{
    Task<List<BookStores>> GetAll(CancellationToken cancellation);
    Task<BookStores> GetById(Guid id, CancellationToken cancellation);
    Task Create(BookStores entity, CancellationToken cancellation);
    Task Update(BookStores entity, CancellationToken cancellation);
}