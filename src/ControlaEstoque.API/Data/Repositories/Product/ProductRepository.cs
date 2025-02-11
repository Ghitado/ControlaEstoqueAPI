using ControlaEstoque.API.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.API.Data.Repositories.Product;

public class ProductRepository : IProductRepository
{
    private readonly ControlaEstoqueDbContext _dbContext;

    public ProductRepository(ControlaEstoqueDbContext dbContext) => _dbContext = dbContext;

    public async Task<Models.Product?> GetById(Guid id)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id); ;
    }

    public async Task<IEnumerable<Models.Product>> GetAll()
    {
        return await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(Models.Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Models.Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Models.Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}
