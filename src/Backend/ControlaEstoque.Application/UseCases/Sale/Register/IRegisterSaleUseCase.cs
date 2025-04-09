using ControlaEstoque.Communication.Requests.Sale;
using ControlaEstoque.Communication.Responses.Sale;

namespace ControlaEstoque.Application.UseCases.Sale.Register;

public interface IRegisterSaleUseCase
{
    Task<ResponseRegisteredSaleJson> Execute(RequestRegisterSaleJson request);
}

