using ControlaEstoque.Communication.Responses.Sale;

namespace ControlaEstoque.Application.UseCases.Sale.Get;

public interface IGetSalesUseCase
{
    Task<ResponseSalesJson> Execute();
}

