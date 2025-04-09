using ControlaEstoque.Communication.Requests.Product;
using ControlaEstoque.Communication.Responses.Product;

namespace ControlaEstoque.Application.UseCases.Product.Register;

public interface IRegisterProductUseCase
{
    Task<ResponseRegisteredProductJson> Execute(RequestRegisterProductFormData request);
}

