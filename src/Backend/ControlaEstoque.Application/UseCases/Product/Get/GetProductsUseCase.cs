using ControlaEstoque.Communication.Responses.Product;
using ControlaEstoque.Domain.Repositories.Product;
using Mapster;

namespace ControlaEstoque.Application.UseCases.Product.Get;

public class GetProductsUseCase : IGetProductsUseCase
{
    private readonly IProductReadOnlyRepository _repositoryRead;

    public GetProductsUseCase(IProductReadOnlyRepository repositoryRead)
    {
        _repositoryRead = repositoryRead;
    }

    public async Task<ResponseProductsJson> Execute()
    {
        var products = await _repositoryRead.Get();

        var responseProducts = products.Select(i => i.Adapt<ResponseProductJson>());

        return new ResponseProductsJson(responseProducts);
    }
}
