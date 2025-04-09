using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Repositories.Product;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.DataAccess.Repositories;

public class ProductRepository : IProductReadOnlyRepository, IProductWriteOnlyRepository
{
    private readonly ControlaEstoqueDbContext _dbContext;

    public ProductRepository(ControlaEstoqueDbContext dbContext) => _dbContext = dbContext;

    public async Task<Product?> GetById(Guid id)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id); ;
    }

    public async Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> productIds)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();
    }


    public async Task<IEnumerable<Product>> Get()
    {
        return await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(Product product)
    {
        await _dbContext.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        _dbContext.Products.Update(product);
    }

    public void Updates(IEnumerable<Product> products)
    {
        _dbContext.Products.UpdateRange(products);
    }

    public async Task Delete(Guid productId)
    {
        var product = await _dbContext.Products.FindAsync(productId);

        _dbContext.Products.Remove(product!);
    }
}
