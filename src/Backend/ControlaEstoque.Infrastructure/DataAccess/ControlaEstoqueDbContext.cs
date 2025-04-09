using ControlaEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.DataAccess;

public class ControlaEstoqueDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> SaleItems { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public ControlaEstoqueDbContext(DbContextOptions<ControlaEstoqueDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControlaEstoqueDbContext).Assembly);
    }
}
