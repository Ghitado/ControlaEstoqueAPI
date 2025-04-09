using ControlaEstoque.Communication.Requests.Product;
using ControlaEstoque.Exception;
using FluentValidation;

namespace ControlaEstoque.Application.UseCases.Product;

public class ProductValidator : AbstractValidator<RequestProductJson>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(product => product.Price).NotEmpty().WithMessage(ResourceMessagesException.PRICE_EMPTY);
        RuleFor(product => product.Stock).GreaterThan(0).WithMessage(ResourceMessagesException.AT_LEAST_ONE_STOCK);
    }
}
