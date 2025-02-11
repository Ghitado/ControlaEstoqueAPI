
using ControlaEstoque.API.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.API.Data.Repositories.Sale;

public class SaleRepository : ISaleRepository
{
    private readonly ControlaEstoqueDbContext _dbContext;

    public SaleRepository(ControlaEstoqueDbContext dbContext) => _dbContext = dbContext;

    public async Task<Models.Sale?> GetById(Guid id)
    {
        return await _dbContext.Sales
            .AsNoTracking()
            .Include(e => e.Items)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Models.Sale>> GetAll()
    {
        return await _dbContext.Sales
            .AsNoTracking()
            .Include(e => e.Items)
            .ToListAsync();
    }

    public async Task Add(Models.Sale sale)
    {
        _dbContext.Sales.Add(sale);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Models.Sale sale)
    {
        _dbContext.Sales.Update(sale);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Models.Sale sale)
    {
        _dbContext.Sales.Remove(sale);
        await _dbContext.SaveChangesAsync();
    }
}
