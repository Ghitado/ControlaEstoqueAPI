using ControlaEstoque.API.Data.Repositories.Product;
using ControlaEstoque.API.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.API.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository) => _repository = repository;

    public async Task<ProductDTO?> GetById(Guid id)
    {
        var product = await _repository.GetById(id);

        if(product is null) 
            return null;

        return product.Adapt<ProductDTO>();
    }

    public async Task<IEnumerable<ProductDTO>> GetAll() 
    { 
        var products = await _repository.GetAll();

        return products.Adapt<List<ProductDTO>>();
    } 

    public async Task Add(ProductInputDTO productDto)
    {
        await _repository.Add(productDto.Adapt<Models.Product>());
    }

    public async Task Update(Guid id, ProductInputDTO productDto)
    {
        var productExist = await _repository.GetById(id);

        if (productExist is null)
            return;

        productExist.Update(
            productDto.Name,
            productDto.Price,
            productDto.Stock,
            productDto.Image);

        await _repository.Update(productExist);
    }

    public async Task Delete(Guid id)
    {
        var productExist = await _repository.GetById(id);

        if (productExist is null)
            return;

        await _repository.Delete(productExist);
    }
}
