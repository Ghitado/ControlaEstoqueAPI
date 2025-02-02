using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Interfaces;
using ControlaEstoque.Domain.Interfaces.Product;
using ControlaEstoque.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.Repositories;
public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ControlaEstoqueDbContext dbContext, IUnitOfWork unitOfWork) 
        : base(dbContext, unitOfWork) { }
    
    //private readonly ControlaEstoqueDbContext _dbContext;

    //public ProductRepository(ControlaEstoqueDbContext context) => _dbContext = context;

    //public async Task<Product> GetById(Guid id)
    //{
    //    var product = await _dbContext.Products
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(u => u.Id == id);

    //    if (product is null)
    //        throw new ArgumentNullException(nameof(product));

    //    return product;
    //}

    //public async Task<IEnumerable<Product>> GetAll() => await _dbContext.Products.ToListAsync();

    //public async Task Update(Guid id, Product product)
    //{
    //    var productExiste = await _dbContext.Products
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(u => u.Id == id);

    //    if (product is null)
    //        throw new ArgumentNullException(nameof(product));

    //    _dbContext.Products.Update(product);
    //    await _dbContext.SaveChangesAsync();
    //}

    //public async Task Add(Product product)
    //{
    //    await _dbContext.AddAsync(product);
    //}

    //public async Task Delete(Guid id)
    //{
    //    var productExist = await _dbContext.Products
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(u => u.Id == id);

    //    if (productExist is null)
    //        throw new ArgumentNullException(nameof(productExist));

    //    _dbContext.Products.Remove(productExist);
    //    await _dbContext.SaveChangesAsync();
    //}
}

