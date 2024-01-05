using CustomerService.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerService.Api.Data;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customers> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly);
    }
}