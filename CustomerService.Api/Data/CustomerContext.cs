using CustomerService.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Api.Data;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customers> Customers { get; set; }
}