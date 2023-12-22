using BookStore.Api.Repositories;

namespace BookStore.Api.Model;

public class BookStores
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = new List<Book>();
    public int QuantityBook => Books.Count();
    public DateTimeOffset DateCreate { get; set; }

    public string DateUpdated { get; set; } = string.Empty;
}