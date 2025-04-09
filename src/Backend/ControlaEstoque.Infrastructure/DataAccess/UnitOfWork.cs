using ControlaEstoque.Domain.Repositories;

namespace ControlaEstoque.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly ControlaEstoqueDbContext _dbContext;

    public UnitOfWork(ControlaEstoqueDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
