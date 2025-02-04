using ControlaEstoque.Domain.Interfaces.Product;
using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Commands.Update;
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository) => _repository = repository;
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);

        if (product is null)
            return false;

        product.Update(
            request.Name,
            request.Price,
            request.Stock,
            request.Image);

        await _repository.Update(request.Id, product);
        return true;
    }
}

