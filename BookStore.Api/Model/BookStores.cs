using BookStore.Api.Repositories;

namespace BookStore.Api.Model;

public class BookStores
{
    public BookStores(BookStoresDTO dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        CPF = dto.CPF;
        Address = dto.Address;
        Books = dto.Books; 
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = new List<Book>();
    public int QuantityBook => Books.Count();
}