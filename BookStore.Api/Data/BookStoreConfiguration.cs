using BookStore.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Api.Data;

public class BookStoreConfiguration : IEntityTypeConfiguration<BookStores>
{
    public void Configure(EntityTypeBuilder<BookStores> builder)
    {
        builder.ToTable("BookStores");
        builder.HasKey(b => b.Id);
    }
}