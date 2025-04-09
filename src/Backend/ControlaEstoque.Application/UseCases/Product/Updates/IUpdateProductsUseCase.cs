using ControlaEstoque.Communication.Requests.Product;

namespace ControlaEstoque.Application.UseCases.Product.Updates;

public interface IUpdateProductsUseCase
{
    Task Execute(RequestUpdateProductsJson productUpdates);
}

