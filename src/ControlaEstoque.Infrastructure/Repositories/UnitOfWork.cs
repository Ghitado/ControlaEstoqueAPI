using ControlaEstoque.Domain.Interfaces;
using ControlaEstoque.Domain.Interfaces.Product;
using ControlaEstoque.Domain.Interfaces.Sale;
using ControlaEstoque.Infrastructure.Context;

namespace ControlaEstoque.Infrastructure.Repositories;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ControlaEstoqueDbContext _dbContext;
    private IProductRepository _productRepository;
    private ISaleRepository _saleRepository;

    public UnitOfWork(ControlaEstoqueDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
    public async Task Dispose() => await _dbContext.DisposeAsync();

    public IProductRepository ProductRepository
    {
        get => _productRepository = _productRepository ?? new ProductRepository(_dbContext, this);
    }

    public ISaleRepository SaleRepository
    {
        get => _saleRepository = _saleRepository ?? new SaleRepository(_dbContext, this);
    }
}

