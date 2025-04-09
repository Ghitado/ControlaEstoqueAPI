namespace ControlaEstoque.Domain.Repositories.Product;

public interface IProductReadOnlyRepository
{
    Task<Entities.Product?> GetById(Guid id);
    Task<IEnumerable<Entities.Product>> GetByIds(IEnumerable<Guid> productIds);
    Task<IEnumerable<Entities.Product>> Get();
}

