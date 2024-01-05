using Transactional.Worker.BookStore;

namespace Transactional.Worker.Client;

public interface IBookStoreHttp
{
    Task CreateBookstore(BookStoreEvent dto, CancellationToken cancellation);
}