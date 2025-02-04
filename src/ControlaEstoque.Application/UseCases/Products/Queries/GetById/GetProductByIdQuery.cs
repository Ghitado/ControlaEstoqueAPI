using ControlaEstoque.Domain.Entities;
using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Queries.GetById;
public class GetProductByIdQuery : IRequest<Product>
{
    public Guid Id { get; set; }
}

