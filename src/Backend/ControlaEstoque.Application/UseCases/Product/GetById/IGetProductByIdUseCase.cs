using ControlaEstoque.Communication.Responses.Product;

namespace ControlaEstoque.Application.UseCases.Product.GetById;

public interface IGetProductByIdUseCase
{
    Task<ResponseProductJson> Execute(Guid id);
}

