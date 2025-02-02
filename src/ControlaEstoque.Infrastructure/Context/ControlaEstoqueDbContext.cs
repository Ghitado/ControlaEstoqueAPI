using ControlaEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.Context;
public class ControlaEstoqueDbContext : DbContext
{
    public ControlaEstoqueDbContext(DbContextOptions<ControlaEstoqueDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControlaEstoqueDbContext).Assembly);
    }
}
