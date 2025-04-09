using ControlaEstoque.Communication.Responses.Sale;
using ControlaEstoque.Domain.Repositories.Sale;
using Mapster;

namespace ControlaEstoque.Application.UseCases.Sale.Get;

public class GetSalesUseCase : IGetSalesUseCase
{
    private readonly ISaleReadOnlyRepository _repositoryRead;

    public GetSalesUseCase(ISaleReadOnlyRepository repositoryRead)
    {
        _repositoryRead = repositoryRead;
    }

    public async Task<ResponseSalesJson> Execute()
    {
        var sales = await _repositoryRead.Get();

        var responseSales = sales.Select(i => i.Adapt<ResponseSaleJson>());

        return new ResponseSalesJson(responseSales);
    }
}
