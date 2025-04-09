using ControlaEstoque.Communication.Responses.Sale;
using ControlaEstoque.Domain.Repositories.Sale;
using Mapster;

namespace ControlaEstoque.Application.UseCases.Sale.GetById;

public class GetSaleByIdUseCase : IGetSaleByIdUseCase
{
    private readonly ISaleReadOnlyRepository _repositoryRead;

    public GetSaleByIdUseCase(ISaleReadOnlyRepository repositoryRead)
    {
        _repositoryRead = repositoryRead;
    }

    public async Task<ResponseSaleJson> Execute(Guid saleId)
    {
        var sale = await _repositoryRead.GetById(saleId);

        return sale.Adapt<ResponseSaleJson>();
    }
}
