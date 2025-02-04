using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Interfaces.Product;
using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Queries.GetById;
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository) => _repository = repository;
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);
        return product!;
    }
}

