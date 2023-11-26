namespace Transactional.Worker.BookStore;

public interface ICreateBookStoreCommandHandler
{
    Task HandleCreateBookStore<T>(T events, CancellationToken cancellationToken) where T:class;
}