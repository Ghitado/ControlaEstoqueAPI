using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Repositories.Sale;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.DataAccess.Repositories;

public class SaleRepository : ISaleReadOnlyRepository, ISaleWriteOnlyRepository
{
    private readonly ControlaEstoqueDbContext _dbContext;

    public SaleRepository(ControlaEstoqueDbContext dbContext) => _dbContext = dbContext;

    public async Task<Sale?> GetById(Guid id)
    {
        return await _dbContext.Sales
            .AsNoTracking()
            .Include(e => e.Items)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Sale>> Get()
    {
        return await _dbContext.Sales
            .AsNoTracking()
            .Include(e => e.Items)
            .ToListAsync();
    }

    public async Task Add(Sale sale)
    {
        await _dbContext.Sales.AddAsync(sale);
    }

    public void Update(Sale sale)
    {
        _dbContext.Sales.Update(sale);
    }

    public async Task Delete(Guid saleId)
    {
        var sale = await _dbContext.Sales.FindAsync(saleId);

        _dbContext.Sales.Remove(sale!);
    }
}
