using ControlaEstoque.Communication.Requests.Product;
using ControlaEstoque.Domain.Repositories.Product;
using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Exception.ExceptionsBase;
using ControlaEstoque.Exception;

namespace ControlaEstoque.Application.UseCases.Product.Updates;

public class UpdateProductsUseCase : IUpdateProductsUseCase
{
    private readonly IProductReadOnlyRepository _productRepositoryRead;
    private readonly IProductWriteOnlyRepository _productRepositoryWrite;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductsUseCase(
        IProductReadOnlyRepository productRepositoryRead,
        IProductWriteOnlyRepository productRepositoryWrite, 
        IUnitOfWork unitOfWork)
    {
        _productRepositoryRead = productRepositoryRead;
        _productRepositoryWrite = productRepositoryWrite;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(RequestUpdateProductsJson productUpdates)
    {
        var productIds = productUpdates.Products.Keys;
        var products = (await _productRepositoryRead.GetByIds(productIds)).ToList();

        foreach (var product in products)
        {
            if (!productUpdates.Products.TryGetValue(product.Id, out var quantityDifference))
                continue;

            if (product.Stock < quantityDifference)
                throw new NotFoundException(ResourceMessagesException.QUANTITY_EXCEEDS_STOCK);

            product.UpdateStock(quantityDifference);
        }

        _productRepositoryWrite.Updates(products);
        await _unitOfWork.Commit();
    }
}
