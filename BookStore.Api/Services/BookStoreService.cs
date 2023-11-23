using BookStore.Api.Model;

namespace BookStore.Api.Services;

public class BookStoreService : IBookStoreService
{
    private readonly List<BookStores> bookStores = new List<BookStores>();

    public BookStoreService()
    {
        bookStores.Add(new BookStores
        {
            Id = Guid.NewGuid(),
            Name = "Casa branca",
            CPF = "000.000.000-21",
            Address = "Rua Congonhas de sertão",
            Books = new List<Book>(){
                    new Book{
                            Id = Guid.NewGuid(),
                            Name = "Harry Potter",
                            Price = 200
                    }
            },
        });
    }
    public Task<List<BookStores>> GetAll()
    {
        return Task.FromResult(bookStores);
    }
}