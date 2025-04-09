namespace ControlaEstoque.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; } 

    public Product() { }

    public Product(string name, decimal price, int stock, string? image)
    {
        Name = name;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public void Update(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void UpdateStock(int quantity) => Stock -= quantity;

    public void IncreaseStock(int quantity) => Stock += quantity; 
}

