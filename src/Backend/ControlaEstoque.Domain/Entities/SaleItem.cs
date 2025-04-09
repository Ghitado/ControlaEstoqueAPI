namespace ControlaEstoque.Domain.Entities;

public sealed class SaleItem : Entity
{
    public Guid SaleId { get; init; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public SaleItem() { }

    public SaleItem(Guid saleId, Guid productId, decimal unitPrice, int quantity)
    {
        SaleId = saleId;
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public void UpdateQuantity(int quantity) => Quantity = quantity; 
}

