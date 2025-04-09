using ControlaEstoque.Communication.Requests.Product;

namespace ControlaEstoque.Application.UseCases.Product.Update;

public interface IUpdateProductUseCase
{
    Task Execute(Guid id, RequestProductJson request);
}

