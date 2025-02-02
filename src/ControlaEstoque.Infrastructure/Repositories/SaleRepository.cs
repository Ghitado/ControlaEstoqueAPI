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

    //private readonly ControlaEstoqueDbContext _context;

    //public SaleRepository(ControlaEstoqueDbContext context) => _context = context;

    //public Task<Sale> GetById(Guid id)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IEnumerable<Sale>> GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //public Task Update(Guid id, Sale sale)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task Add(Sale sale)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task Delete(Guid id)
    //{
    //    throw new NotImplementedException();
    //}
}
