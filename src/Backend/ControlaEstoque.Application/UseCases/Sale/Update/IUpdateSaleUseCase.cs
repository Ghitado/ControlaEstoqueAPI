using ControlaEstoque.Communication.Requests.Sale;

namespace ControlaEstoque.Application.UseCases.Sale.Update;

public interface IUpdateSaleUseCase
{
    Task Execute(Guid id, RequestSaleJson request);
}

