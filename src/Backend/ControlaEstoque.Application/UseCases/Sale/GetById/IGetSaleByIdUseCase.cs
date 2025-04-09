using ControlaEstoque.Communication.Responses.Sale;

namespace ControlaEstoque.Application.UseCases.Sale.GetById;

public interface IGetSaleByIdUseCase
{
    Task<ResponseSaleJson> Execute(Guid id);
}

