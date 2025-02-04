using ControlaEstoque.Domain.Entities;
using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Queries.GetAll;
public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{

}