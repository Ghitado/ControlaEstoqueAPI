using ControlaEstoque.Application.UseCases.Product.Delete;
using ControlaEstoque.Application.UseCases.Product.Get;
using ControlaEstoque.Application.UseCases.Product.GetById;
using ControlaEstoque.Application.UseCases.Product.Register;
using ControlaEstoque.Application.UseCases.Product.Update;
using ControlaEstoque.Application.UseCases.Product.Updates;
using ControlaEstoque.Communication.Requests.Product;
using ControlaEstoque.Communication.Responses;
using ControlaEstoque.Communication.Responses.Product;
using Microsoft.AspNetCore.Mvc;

namespace ControlaEstoque.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseProductJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetProductByIdUseCase useCase,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var product = await useCase.Execute(id);

        return Ok(product);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseProductsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(
        [FromServices] IGetProductsUseCase useCase,
        CancellationToken cancellationToken)
    {
        var products = await useCase.Execute();

        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredProductJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterProductUseCase useCase,
        [FromForm] RequestRegisterProductFormData request,
        CancellationToken cancellationToken)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteProductUseCase useCase,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
       [FromServices] IUpdateProductUseCase useCase,
       [FromRoute] Guid id,
       [FromBody] RequestProductJson request,
       CancellationToken cancellationToken)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpPut("products")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
       [FromServices] IUpdateProductsUseCase useCase,
       [FromBody] RequestUpdateProductsJson request,
       CancellationToken cancellationToken)
    {
        await useCase.Execute(request);

        return NoContent();
    }
}
