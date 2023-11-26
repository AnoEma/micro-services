namespace Transactional.Worker.BookStore;

public record BookStoreEvent
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string CPF { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public List<Book> Books { get; init; } = new List<Book>();
    public int QuantityBook => Books.Count();
}