using ControlaEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.API.Data.Context;

public class ControlaEstoqueDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> SaleItems { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public ControlaEstoqueDbContext(DbContextOptions<ControlaEstoqueDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControlaEstoqueDbContext).Assembly);
    }
}
