using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Commands.Delete;
public class DeleteProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

