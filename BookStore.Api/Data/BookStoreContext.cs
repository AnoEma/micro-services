using BookStore.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BookStores> BookStores { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreContext).Assembly);
    }
}