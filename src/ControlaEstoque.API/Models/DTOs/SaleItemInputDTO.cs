namespace ControlaEstoque.API.Models.DTOs;

public class SaleItemInputDTO
{
    public required Guid ProductId { get; set; }
    public ushort Quantity { get; set; }
}
