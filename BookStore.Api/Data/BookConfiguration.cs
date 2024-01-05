
using BookStore.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Api.Data;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name);
        builder.Property(b => b.Price)
            .HasColumnType("Price")
            .HasPrecision(18, 2);

        builder.HasOne(x => x.Bookstores)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.BookstoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}