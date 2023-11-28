namespace Transactional.Worker.BookStore;

public interface IBookStoreCreatedEventConsumer
{
    Task <BookStoreEvent> GetBookstore();
}