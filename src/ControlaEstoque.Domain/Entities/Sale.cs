namespace ControlaEstoque.Domain.Entities;
public sealed class Sale : Entity
{
    public string Buyer { get; private set; } = string.Empty;
    public bool Paid { get; private set; } = false;
    public string Description { get; private set; } = string.Empty;
    public DateTime DateSale { get; init; } = DateTime.UtcNow;
    public List<SaleItem> Items { get; private set; } = [];
    public decimal TotalValue => Items.Sum(item => item.TotalPrice);

    public Sale() { }

    public Sale(string buyer, string description, List<SaleItem> items)
    {
        Buyer = buyer;
        Description = description;
        Items = items;
    }

    public void AddItem(Product product, ushort quantity)
    {
        var SaleItem = new SaleItem(this, product, quantity);
        Items.Add(SaleItem);
    }

    public void RemoveItem(Product product, ushort quantity)
    {
        var saleItem = Items.FirstOrDefault(item => item.Product == product);

        if (saleItem is not null)
            Items.Remove(saleItem);
    }

    public void MarkAsPaid()
    {
        Paid = true;
    }
}

