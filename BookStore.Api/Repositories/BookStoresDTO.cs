using BookStore.Api.Model;

namespace BookStore.Api.Repositories;

public record BookStoresDTO(string Name, string CPF, string Address, List<Book> Books)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTimeOffset DateCreated { get; set; }
    public string DateUpdated { get; set; }
}