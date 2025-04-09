using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Domain.Repositories.Product;
using ControlaEstoque.Exception;
using ControlaEstoque.Exception.ExceptionsBase;

namespace ControlaEstoque.Application.UseCases.Product.Delete;

public class DeleteProductUseCase : IDeleteProductUseCase
{
    private readonly IProductReadOnlyRepository _repositoryRead;
    private readonly IProductWriteOnlyRepository _repositoryWrite;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductUseCase(
        IProductReadOnlyRepository repositoryRead,
        IProductWriteOnlyRepository repositoryWrite,
        IUnitOfWork unitOfWork)
    {
        _repositoryRead = repositoryRead;
        _repositoryWrite = repositoryWrite;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid productId)
    {
        var product = await _repositoryRead.GetById(productId);

        if (product is null)
            throw new NotFoundException(ResourceMessagesException.PRODUCT_NOT_FOUND);

        await _repositoryWrite.Delete(productId);
        await _unitOfWork.Commit();
    }
}
