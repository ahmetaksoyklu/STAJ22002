using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using Application.Features.Products.Queries.GetListByCategoryId;
using Application.Features.Products.Queries.GetListByUnitPriceRange;
using Application.Features.Products.Queries.GetProductDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    
    
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreatedProductResponse>> Create(
        [FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        CreatedProductResponse response = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetListProductListItem>>> GetList(CancellationToken cancellationToken)
    {
        List<GetListProductListItem> response = await _mediator.Send(new GetListProductQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetByIdProductResponse>> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        GetByIdProductResponse response = await _mediator.Send(new GetByIdProductQuery { Id = id }, cancellationToken);
        return Ok(response);
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ActionResult<List<GetListProductListItem>>> GetByCategory(
        [FromRoute] int categoryId,
        CancellationToken cancellationToken)
    {
        List<GetListProductListItem> response = await _mediator.Send(
            new GetListProductsByCategoryIdQuery { CategoryId = categoryId },
            cancellationToken);
        return Ok(response);
    }

    [HttpGet("by-unit-price")]
    public async Task<ActionResult<List<GetListProductListItem>>> GetByUnitPrice(
        [FromQuery] decimal min,
        [FromQuery] decimal max,
        CancellationToken cancellationToken)
    {
        List<GetListProductListItem> response = await _mediator.Send(
            new GetListProductsByUnitPriceRangeQuery { Min = min, Max = max },
            cancellationToken);
        return Ok(response);
    }

    [HttpGet("details")]
    public async Task<ActionResult<List<ProductDetailListItem>>> GetProductDetails(CancellationToken cancellationToken)
    {
        List<ProductDetailListItem> response = await _mediator.Send(new GetProductDetailsQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedProductResponse>> Update(
        [FromBody] UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        UpdatedProductResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DeletedProductResponse>> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        DeletedProductResponse response = await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken);
        return Ok(response);
    }
}
