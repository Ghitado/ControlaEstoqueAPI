namespace ControlaEstoque.Application.DTOs;

public class SaleDTO
{
    public Guid? Id { get; set; }
    public string Buyer { get; set; } = string.Empty;
    public bool Paid { get; set; }
    public string Observations { get; set; } = string.Empty;
    public DateTime DateSale { get; set; }
    public decimal TotalValue { get; set; }
    public List<SaleItemDTO> Items { get; set; } = new();
}