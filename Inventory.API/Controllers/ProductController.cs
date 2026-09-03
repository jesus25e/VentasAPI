using Inventory.Application.Features.Products.Commands.CreateProduct;
using Inventory.Application.Features.Products.Commands.DeleteProduct;
using Inventory.Application.Features.Products.Commands.UpdateProduct;
using Inventory.Application.Features.Products.Queries.GetAllProducts;
using Inventory.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result.IsSuccess) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return NotFound(result);

            return CreatedAtAction(nameof(GetById),
                new { id = result.Value }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess) return NotFound(result);

            return Ok(result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("El Id no coincide con los productos.");
            }

            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return NotFound(result);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id, true);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return NotFound(result);
            return Ok(result);
        }
    }
}
