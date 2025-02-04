using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Interfaces;
using ControlaEstoque.Domain.Interfaces.Sale;
using ControlaEstoque.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.Repositories;
public class SaleRepository : Repository<Sale>, ISaleRepository
{
    public SaleRepository(ControlaEstoqueDbContext dbContext, IUnitOfWork unitOfWork) 
        : base(dbContext, unitOfWork) { }
}
