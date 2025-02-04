using ControlaEstoque.Application.Interfaces;
using ControlaEstoque.Application.UseCases.Products.Commands.Create;
using ControlaEstoque.Application.UseCases.Products.Commands.Delete;
using ControlaEstoque.Application.UseCases.Products.Commands.Update;
using ControlaEstoque.Application.UseCases.Products.Queries.GetAll;
using ControlaEstoque.Application.UseCases.Products.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlaEstoque.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly IMediator _mediator;

    public ProductController(IProductService service, IMediator mediator)
    {
        _service = service;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] GetProductByIdQuery id)
    {
        var product = await _mediator.Send(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return Ok(new { ProductId = productId });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(
        [FromRoute] Guid id, 
        [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest("O ID do produto na URL não corresponde ao ID no corpo da requisição.");

        var success = await _mediator.Send(command);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand id)
    {
        var success = await _mediator.Send(id);
        return success ? NoContent() : NotFound();
    }
}
