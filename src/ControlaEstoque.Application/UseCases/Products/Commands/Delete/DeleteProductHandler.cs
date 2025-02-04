using ControlaEstoque.Domain.Interfaces.Product;
using MediatR;

namespace ControlaEstoque.Application.UseCases.Products.Commands.Delete;
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);

        if (product is null)
            return false;

        await _repository.Delete(request.Id);
        return true;
    }
}

