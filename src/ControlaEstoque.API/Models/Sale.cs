namespace ControlaEstoque.API.Models;
public sealed class Sale : Entity
{
    public string Buyer { get; private set; } = string.Empty;
    public bool Paid { get; private set; } = false;
    public string Description { get; private set; } = string.Empty;
    public DateTime DateSale { get; init; } = DateTime.UtcNow;
    public List<SaleItem> Items { get; private set; } = [];
    public decimal TotalValue => Items.Sum(item => item.TotalPrice);

    public Sale() { }

    public Sale(string buyer, bool paid, string description)
    {
        Buyer = buyer;
        Paid = paid;
        Description = description;
    }

    public void AddItem(Guid productId, decimal unitPrice, ushort quantity)
    {
        if (quantity == 0)
            throw new InvalidOperationException("Quantity must be greater than zero.");

        var saleItem = new SaleItem(this.Id, productId, unitPrice, quantity);
        Items.Add(saleItem);
    }

    public void UpdateBuyer(string buyer) { Buyer = buyer; }
    public void UpdatePaid(bool paid) { Paid = paid; }
    public void UpdateDescription(string description) { Description = description; }
    public void RemoveItem(SaleItem item) { Items.Remove(item); }
}

