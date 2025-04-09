using ControlaEstoque.Application.UseCases.Sale.Delete;
using ControlaEstoque.Application.UseCases.Sale.Get;
using ControlaEstoque.Application.UseCases.Sale.GetById;
using ControlaEstoque.Application.UseCases.Sale.Register;
using ControlaEstoque.Application.UseCases.Sale.Update;
using ControlaEstoque.Communication.Requests.Sale;
using ControlaEstoque.Communication.Responses;
using ControlaEstoque.Communication.Responses.Sale;
using Microsoft.AspNetCore.Mvc;

namespace ControlaEstoque.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseSaleJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetSaleByIdUseCase useCase,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var product = await useCase.Execute(id);

        return Ok(product);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseSalesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(
        [FromServices] IGetSalesUseCase useCase,
        CancellationToken cancellationToken)
    {
        var products = await useCase.Execute();

        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredSaleJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterSaleUseCase useCase,
        [FromBody] RequestRegisterSaleJson request,
        CancellationToken cancellationToken)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteSaleUseCase useCase,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await useCase.Execute(id);

        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateSaleUseCase useCase,
        [FromBody] RequestSaleJson request,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await useCase.Execute(id, request);

        return Ok();
    }
}
