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
}

