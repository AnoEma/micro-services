namespace Transactional.Worker.BookStore;

public record Book
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; } = 0;
}