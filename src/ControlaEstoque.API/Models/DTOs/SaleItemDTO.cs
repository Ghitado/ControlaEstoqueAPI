namespace ControlaEstoque.API.Models.DTOs;

public class SaleItemDTO
{
    public Guid SaleId { get; set; }
    public required Guid ProductId { get; set; }
    public ushort Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;
}
