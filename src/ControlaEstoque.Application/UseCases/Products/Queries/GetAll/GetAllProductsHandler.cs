using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Interfaces.Product;
using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Queries.GetAll;
public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAll();
    }
}

