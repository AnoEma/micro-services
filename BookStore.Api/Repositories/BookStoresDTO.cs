using BookStore.Api.Model;

namespace BookStore.Api.Repositories;

public record BookStoresDTO(Guid Id, string Name, string CPF, string Address, List<Book> Books)
{
    public required DateTimeOffset DateCreated { get; set; } = new DateTimeOffset();
    public string DateUpdated { get; set; } = string.Empty;
}