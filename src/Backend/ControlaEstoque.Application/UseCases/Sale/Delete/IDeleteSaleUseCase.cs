namespace ControlaEstoque.Application.UseCases.Sale.Delete;

public interface IDeleteSaleUseCase
{
    Task Execute(Guid id);
}

