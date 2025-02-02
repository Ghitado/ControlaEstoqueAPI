namespace ControlaEstoque.Domain.Entities;
public sealed class SaleItem : Entity
{
    public Sale Sale { get; private set; }
    public Product Product { get; private set; }
    public ushort Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public SaleItem() { }

    public SaleItem(Sale sale, Product product, ushort quantity)
    {
        Sale = sale;
        Product = product;
        Quantity = quantity;
        UnitPrice = product.Price; 
    }
}

