using ControlaEstoque.Application.UseCases.Product.Updates;
using ControlaEstoque.Communication.Requests.Product;
using ControlaEstoque.Communication.Requests.Sale;
using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Domain.Repositories.Product;
using ControlaEstoque.Domain.Repositories.Sale;
using ControlaEstoque.Exception;
using ControlaEstoque.Exception.ExceptionsBase;

namespace ControlaEstoque.Application.UseCases.Sale.Update;

public class UpdateSaleUseCase : IUpdateSaleUseCase
{
    private readonly IProductReadOnlyRepository _productRepositoryRead;
    private readonly ISaleReadOnlyRepository _saleRepositoryRead;
    private readonly ISaleWriteOnlyRepository _saleRepositoryWrite;
    private readonly IUpdateProductsUseCase _updateProductsUseCase;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSaleUseCase(
        IProductReadOnlyRepository productRepositoryRead,
        IProductWriteOnlyRepository productRepositoryWrite,
        ISaleReadOnlyRepository saleRepositoryRead,
        ISaleWriteOnlyRepository saleRepositoryWrite,
        IUpdateProductsUseCase updateProductsUseCase,
        IUnitOfWork unitOfWork)
    {
        _productRepositoryRead = productRepositoryRead;
        _saleRepositoryRead = saleRepositoryRead;
        _saleRepositoryWrite = saleRepositoryWrite;
        _updateProductsUseCase = updateProductsUseCase;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id, RequestSaleJson request)
    {
        var saleExist = await _saleRepositoryRead.GetById(id);
        if (saleExist is null)
            throw new NotFoundException(ResourceMessagesException.SALE_NOT_FOUND);

        saleExist.UpdateBuyer(request.Buyer);
        saleExist.UpdateDescription(request.Description);
        saleExist.UpdatePaid(request.Paid);

        var existingItems = saleExist.Items.ToDictionary(si => si.ProductId);
        var productIds = request.Items.Select(i => i.ProductId).ToHashSet();
        var products = (await _productRepositoryRead.GetByIds(productIds)).ToDictionary(p => p.Id);

        var productUpdates = new Dictionary<Guid, int>();

        foreach (var item in request.Items)
        {
            if (!products.TryGetValue(item.ProductId, out var product))
                throw new NotFoundException(ResourceMessagesException.PRODUCT_NOT_FOUND);

            var quantityDifference = item.Quantity;

            if (existingItems.TryGetValue(item.ProductId, out var existingItem))
            {
                quantityDifference -= existingItem.Quantity;
                existingItem.UpdateQuantity(item.Quantity);
            }
            else
            {
                saleExist.AddItem(product.Id, product.Price, item.Quantity);
            }

            productUpdates[item.ProductId] = quantityDifference;
        }

        await _updateProductsUseCase.Execute(new RequestUpdateProductsJson(productUpdates));

        _saleRepositoryWrite.Update(saleExist);
        await _unitOfWork.Commit();
    }
}
