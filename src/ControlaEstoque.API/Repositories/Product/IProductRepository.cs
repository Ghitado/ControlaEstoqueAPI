namespace ControlaEstoque.API.Repositories.Product;

public interface IProductRepository
{
    Task<Models.Product?> GetById(Guid id);
    Task<IEnumerable<Models.Product>> GetAll();
    Task Add(Models.Product product);
    Task Update(Models.Product product);
    Task Delete(Models.Product product);
}