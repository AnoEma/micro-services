using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Api.Model;

public class Book
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Bookstores")]
    public Guid BookstoreId { get; set; }
    public BookStores? Bookstores { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
}