using ControlaEstoque.Application.DTOs;

namespace ControlaEstoque.Application.Interfaces;
public interface IProductService
{
    Task<ProductDTO> GetById(Guid id);
    Task<IEnumerable<ProductDTO>> GetAll();
    Task Add(ProductDTO productDTO);
    Task Update(Guid id, ProductDTO productDTO);
    Task Delete(Guid id);
}

