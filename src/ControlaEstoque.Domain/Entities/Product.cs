namespace ControlaEstoque.Domain.Entities;
public sealed class Product : Entity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public ushort Stock { get; private set; }

    public Product() { }

    public Product(string name, decimal price, ushort stock)
    {
        Name = name;
        Price = price;  
        Stock = stock;
    }
}

