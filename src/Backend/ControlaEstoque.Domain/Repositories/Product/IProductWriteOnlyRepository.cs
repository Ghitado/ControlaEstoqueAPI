namespace ControlaEstoque.Domain.Repositories.Product;

public interface IProductWriteOnlyRepository
{
    Task Add(Entities.Product product);
    void Update(Entities.Product product);
    void Updates(IEnumerable<Entities.Product> products);
    Task Delete(Guid productId);
}

