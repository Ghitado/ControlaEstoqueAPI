
using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Domain.Repositories.Sale;
using ControlaEstoque.Exception;
using ControlaEstoque.Exception.ExceptionsBase;

namespace ControlaEstoque.Application.UseCases.Sale.Delete;

public class DeleteSaleUseCase : IDeleteSaleUseCase
{
    private readonly ISaleReadOnlyRepository _repositoryRead;
    private readonly ISaleWriteOnlyRepository _repositoryWrite;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSaleUseCase(
        ISaleReadOnlyRepository repositoryRead,
        ISaleWriteOnlyRepository repositoryWrite, 
        IUnitOfWork unitOfWork)
    {
        _repositoryRead = repositoryRead;
        _repositoryWrite = repositoryWrite;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid saleId)
    {
        var sale = await _repositoryRead.GetById(saleId);

        if (sale is null)
            throw new NotFoundException(ResourceMessagesException.SALE_NOT_FOUND);

        await _repositoryWrite.Delete(saleId);
        await _unitOfWork.Commit();
    }
}
