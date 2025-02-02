namespace ControlaEstoque.Domain.Entities;
public sealed class Sale : Entity
{
    public string Buyer { get; private set; } = string.Empty;
    public bool Paid { get; private set; } = false;
    public string Observations { get; private set; } = string.Empty;
    public DateTime DateSale { get; init; } = DateTime.UtcNow;
    public List<SaleItem> Items { get; private set; } = [];
    public decimal TotalValue => Items.Sum(item => item.TotalPrice);

    public Sale() { }

    public Sale(string buyer, string observations, List<SaleItem> items)
    {
        Buyer = buyer;
        Observations = observations;
        Items = items;
    }

    public void AddItem(Product product, ushort quantity)
    {
        var SaleItem = new SaleItem(this, product, quantity);
        Items.Add(SaleItem);
    }

    public void MarkAsPaid()
    {
        Paid = true;
    }
}

