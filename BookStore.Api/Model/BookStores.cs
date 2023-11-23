namespace BookStore.Api.Model;

public class BookStores
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<Book> Books { get; set; }
}