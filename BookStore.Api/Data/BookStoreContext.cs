using BookStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public class BookStoreContext : DbContext
{
    public DbSet<BookStoresDTO> BookStores { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("localhost");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookStoresDTO>().ComplexProperty(x => x.Books);
    }
}