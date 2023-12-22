using BookStore.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BookStores> BookStores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookStores>().ComplexProperty(x => x.Books);
    }
}