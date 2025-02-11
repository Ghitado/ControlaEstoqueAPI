namespace ControlaEstoque.API.Models.DTOs;

public class SaleDTO
{
    public Guid Id { get; set; }
    public string Buyer { get; set; } = string.Empty;
    public bool Paid { get; set; } = false;
    public string Description { get; set; } = string.Empty;
    public List<SaleItemDTO> Items { get; set; } = [];
}
