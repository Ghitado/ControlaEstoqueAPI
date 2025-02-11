namespace ControlaEstoque.API.Models;
public sealed class SaleItem : Entity
{
    public Guid SaleId { get; init; }
    public Guid ProductId { get; private set; }
    public ushort Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public SaleItem() { }

    public SaleItem(Guid saleId, Guid productId, decimal unitPrice, ushort quantity)
    {
        SaleId = saleId;
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public void UpdateQuantity(ushort quantity) { Quantity = quantity; }
}

