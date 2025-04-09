using ControlaEstoque.Communication.Requests.Sale;
using ControlaEstoque.Communication.Responses.Sale;
using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Domain.Repositories.Product;
using ControlaEstoque.Domain.Repositories.Sale;
using ControlaEstoque.Exception;
using ControlaEstoque.Exception.ExceptionsBase;
using Mapster;

namespace ControlaEstoque.Application.UseCases.Sale.Register;

public class RegisterSaleUseCase : IRegisterSaleUseCase
{
    private readonly IProductReadOnlyRepository _productRepositoryRead;
    private readonly IProductWriteOnlyRepository _productRepositoryWrite;
    private readonly ISaleWriteOnlyRepository _saleRepositoryWrite;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterSaleUseCase(
        IProductReadOnlyRepository productRepositoryRead,
        IProductWriteOnlyRepository productRepositoryWrite,
        ISaleWriteOnlyRepository saleRepositoryWrite,
        IUnitOfWork unitOfWork)
    {
        _productRepositoryRead = productRepositoryRead;
        _productRepositoryWrite = productRepositoryWrite;
        _saleRepositoryWrite = saleRepositoryWrite;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisteredSaleJson> Execute(RequestRegisterSaleJson request)
    {
        var sale = request.Adapt<Domain.Entities.Sale>();
        sale.Items.Clear();

        foreach (var item in request.Items)
        {
            var product = await _productRepositoryRead.GetById(item.ProductId);

            if (product is null)
                throw new NotFoundException(ResourceMessagesException.SALE_NOT_FOUND);

            if (product.Stock < item.Quantity)
                throw new NotFoundException(ResourceMessagesException.QUANTITY_EXCEEDS_STOCK);

            sale.AddItem(product.Id, product.Price, item.Quantity);
            product.UpdateStock(item.Quantity);
            _productRepositoryWrite.Update(product);
        }

        await _saleRepositoryWrite.Add(sale);
        await _unitOfWork.Commit();

        return sale.Adapt<ResponseRegisteredSaleJson>();
    }
}
