using ControlaEstoque.Communication.Requests.Product;
using ControlaEstoque.Communication.Responses.Product;
using ControlaEstoque.Domain.Extensions;
using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Domain.Repositories.Product;
using ControlaEstoque.Exception.ExceptionsBase;
using Mapster;

namespace ControlaEstoque.Application.UseCases.Product.Register;

public class RegisterProductUseCase : IRegisterProductUseCase
{
    private readonly IProductWriteOnlyRepository _repositoryWrite;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterProductUseCase(
        IProductWriteOnlyRepository repositoryWrite,
        IUnitOfWork unitOfWork)
    {
        _repositoryWrite = repositoryWrite;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisteredProductJson> Execute(RequestRegisterProductFormData request)
    {
        Validate(request);

        var product = request.Adapt<Domain.Entities.Product>();

        await _repositoryWrite.Add(product);
        await _unitOfWork.Commit();

        return new ResponseRegisteredProductJson(product.Id, product.Name);
    }

    private static void Validate(RequestProductJson request)
    {
        var result = new ProductValidator().Validate(request);

        if (result.IsValid.IsFalse())
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
    }
}
