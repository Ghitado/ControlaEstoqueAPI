namespace ControlaEstoque.API.Models.DTOs;

public class ProductInputDTO
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ushort Stock { get; set; }
    public string Image { get; set; } = "";
}
