using ControlaEstoque.Communication.Responses.Product;

namespace ControlaEstoque.Application.UseCases.Product.Get;

public interface IGetProductsUseCase
{
    Task<ResponseProductsJson> Execute();
}
