using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Commands.Update;
public class UpdateProductCommand : IRequest<bool>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ushort Stock { get; set; }
    public string Image { get; set; } = string.Empty;
}

