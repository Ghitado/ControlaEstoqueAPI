using ControlaEstoque.API.Data.Repositories.Product;
using ControlaEstoque.API.Data.Repositories.Sale;
using ControlaEstoque.API.Models;
using ControlaEstoque.API.Models.DTOs;
using Mapster;

namespace ControlaEstoque.API.Services.Sale;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;

    public SaleService(
        ISaleRepository saleRepository,
        IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }

    public async Task<SaleDTO?> GetById(Guid id)
    {
        var saleExist = await _saleRepository.GetById(id);

        if (saleExist is null)
            return null;

        return saleExist.Adapt<SaleDTO>();
    }

    public async Task<IEnumerable<SaleDTO>> GetAll()
    {
        var sales = await _saleRepository.GetAll();

        return sales.Adapt<List<SaleDTO>>();
    }

    public async Task Add(SaleInputDTO saleDto)
    {
        var sale = saleDto.Adapt<Models.Sale>();
        sale.Items.Clear();

        foreach (var item in saleDto.Items)
        {
            var product = await _productRepository.GetById(item.ProductId);

            if (product is null)
                throw new Exception("Product not found");

            if (product.Stock < item.Quantity)
                throw new Exception("Not enough stock");

            sale.AddItem(product.Id, product.Price, item.Quantity);
            product.DecreaseStock(item.Quantity);
            await _productRepository.Update(product);
        }

        await _saleRepository.Add(sale);
    }

    public async Task Update(Guid id, SaleInputDTO saleDto)
    {
        var saleExist = await _saleRepository.GetById(id);

        if (saleExist is null)
            return;

        saleExist.UpdateBuyer(saleDto.Buyer);
        saleExist.UpdateDescription(saleDto.Description);
        saleExist.UpdatePaid(saleDto.Paid);

        var existingItems = saleExist.Items.ToList();

        foreach (var item in saleDto.Items)
        {
            var product = await _productRepository.GetById(item.ProductId);
            if (product is null)
                throw new Exception("Product not found");

            var existingItem = existingItems.FirstOrDefault(si => si.ProductId == item.ProductId);

            if (existingItem is not null)
            {
                var quantityDifference = item.Quantity - existingItem.Quantity;

                if (product.Stock < quantityDifference)
                    throw new Exception("Not enough stock");

                existingItem.UpdateQuantity(item.Quantity);
                product.DecreaseStock(quantityDifference);
            }
            else
            {
                if (product.Stock < item.Quantity)
                    throw new Exception("Not enough stock");

                saleExist.AddItem(product.Id, product.Price, item.Quantity);
                product.DecreaseStock(item.Quantity);
            }

            await _productRepository.Update(product);
        }

        var itemsToRemove = existingItems.Where(si => !saleDto.Items.Any(i => i.ProductId == si.ProductId)).ToList();
        foreach (var item in itemsToRemove)
        {
            var product = await _productRepository.GetById(item.ProductId);
            product.IncreaseStock(item.Quantity);
            saleExist.RemoveItem(item);
            await _productRepository.Update(product);
        }

        await _saleRepository.Update(saleExist);
    }

    public async Task Delete(Guid id)
    {
        var saleExist = await _saleRepository.GetById(id);

        if (saleExist is null)
            return;

        await _saleRepository.Delete(saleExist);
    }
}
