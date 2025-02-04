using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Commands.Create;
public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ushort Stock { get; set; }
    public string Image { get; set; } = string.Empty;
}

