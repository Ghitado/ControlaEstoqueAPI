namespace ControlaEstoque.Application.DTOs;
public class SaleItemDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public ushort Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
