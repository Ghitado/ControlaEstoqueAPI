using ControlaEstoque.Application.DTOs;
using ControlaEstoque.Application.Interfaces;
using ControlaEstoque.Domain.Entities;

namespace ControlaEstoque.Application.Mappings;
public class ProductMapper : IMapper<Product, ProductDTO>
{
    public Product MapToEntity(ProductDTO dto) => 
        new(
            dto.Name,
            dto.Price,
            dto.Stock, 
            dto.Image);

    public ProductDTO MapToDTO(Product entity) =>
        new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Stock = entity.Stock,
            Image = entity.Image
        };

    public IEnumerable<ProductDTO> MapToDTOList(IEnumerable<Product> products)
    {
        if (products is null || !products.Any()) 
            return [];

        return products.Select(product => new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Image = product.Image
        }).ToList();
    }
}

