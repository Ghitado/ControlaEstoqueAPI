using ControlaEstoque.Application.DTOs;
using ControlaEstoque.Application.Interfaces;
using ControlaEstoque.Application.Mappings;
using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Interfaces.Product;

namespace ControlaEstoque.Application.Services;
public class ProductService : IProductService
{
    private readonly ProductMapper _mapper;
    private readonly IProductRepository _repository;

    public ProductService(ProductMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ProductDTO> GetById(Guid id)
    {
        var product = await _repository.GetById(id);
        return _mapper.MapToDTO(product!);
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var products = await _repository.GetAll();
        return _mapper.MapToDTOList(products);
    }

    public async Task Add(ProductDTO productDTO)
    {
        var product = _mapper.MapToEntity(productDTO);
        await _repository.Add(product);
    }

    public async Task Update(Guid id, ProductDTO productDTO)
    {
        var productExist = await _repository.GetById(id);

        if (productExist is null)
            return;

        var product = _mapper.MapToEntity(productDTO);
        await _repository.Update(id, product);
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
    }
}

