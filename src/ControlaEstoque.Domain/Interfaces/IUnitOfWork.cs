using ControlaEstoque.Domain.Interfaces.Product;
using ControlaEstoque.Domain.Interfaces.Sale;

namespace ControlaEstoque.Domain.Interfaces;
public interface IUnitOfWork
{
    Task Commit();
    Task Dispose();
    IProductRepository ProductRepository { get; }
    ISaleRepository SaleRepository { get; }
}

