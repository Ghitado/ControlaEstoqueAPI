using ControlaEstoque.Communication.Responses.Product;
using ControlaEstoque.Domain.Repositories.Product;
using Mapster;

namespace ControlaEstoque.Application.UseCases.Product.GetById;

public class GetProductByIdUseCase : IGetProductByIdUseCase
{
    private readonly IProductReadOnlyRepository _repositoryRead;

    public GetProductByIdUseCase(IProductReadOnlyRepository repositoryRead)
    {
        _repositoryRead = repositoryRead;
    }

    public async Task<ResponseProductJson> Execute(Guid productId)
    {
        var product = await _repositoryRead.GetById(productId);

        return product.Adapt<ResponseProductJson>();
    }
}
