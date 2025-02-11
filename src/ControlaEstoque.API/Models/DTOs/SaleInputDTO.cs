namespace ControlaEstoque.API.Models.DTOs;

public class SaleInputDTO
{
    public string Buyer { get; set; } = string.Empty;
    public bool Paid { get; set; } = false;
    public string Description { get; set; } = string.Empty;
    public List<SaleItemInputDTO> Items { get; set; } = [];
}
