namespace ControlaEstoque.Application.UseCases.Product.Delete;

public interface IDeleteProductUseCase
{
    Task Execute(Guid productId);
}

