using ControlaEstoque.Communication.Requests.Product;
using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Domain.Repositories.Product;
using ControlaEstoque.Exception;
using ControlaEstoque.Exception.ExceptionsBase;

namespace ControlaEstoque.Application.UseCases.Product.Update;

public class UpdateProductUseCase : IUpdateProductUseCase
{
    private readonly IProductReadOnlyRepository _repositoryRead;
    private readonly IProductWriteOnlyRepository _repositoryWrite;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductUseCase(
        IProductReadOnlyRepository repositoryRead,
        IProductWriteOnlyRepository repositoryWrite,
        IUnitOfWork unitOfWork)
    {
        _repositoryRead = repositoryRead;
        _repositoryWrite = repositoryWrite;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id, RequestProductJson request)
    {
        var productExist = await _repositoryRead.GetById(id);

        if (productExist is null)
            throw new NotFoundException(ResourceMessagesException.PRODUCT_NOT_FOUND);

        productExist.Update(
            request.Name,
            request.Price,
            request.Stock);

        _repositoryWrite.Update(productExist);
        await _unitOfWork.Commit();
    }

}
