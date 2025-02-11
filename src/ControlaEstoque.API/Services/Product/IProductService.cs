using ControlaEstoque.API.Models.DTOs;

namespace ControlaEstoque.API.Services.Product;

public interface IProductService
{
    Task<ProductDTO?> GetById(Guid id);
    Task<IEnumerable<ProductDTO>> GetAll();
    Task Add(ProductInputDTO product);
    Task Update(Guid id, ProductInputDTO product);
    Task Delete(Guid id);
}
