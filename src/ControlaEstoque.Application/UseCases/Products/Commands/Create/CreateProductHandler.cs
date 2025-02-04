using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Interfaces.Product;
using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Commands.Create;
public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository) => _repository = repository;

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        (
            request.Name,
            request.Price,
            request.Stock,
            request.Image
        );

        await _repository.Add(product);
        return product.Id;
    }
}

