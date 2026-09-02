using Inventory.Application.Features.Supplier.Commands.CreateSupplier;
using Inventory.Application.Features.Supplier.Commands.DeleteSupplier;
using Inventory.Application.Features.Supplier.Commands.UpdateSupplier;
using Inventory.Application.Features.Supplier.Queries.GetAllSupplier;
using Inventory.Application.Features.Supplier.Queries.GetSupplierById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSupplierQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result.IsSuccess) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create ( CreateSupplierCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.IsSuccess) return BadRequest(result);
            return CreatedAtAction(nameof(GetById),
                new { id = result.Value},result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var query = new GetSupplierByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess) return NotFound(result);
            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Update (int id, UpdateSupplierCommand command)
        {
            if (id != command.Id) return BadRequest("El id no coincide con los productos.");
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return NotFound(result);
            
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (int id)
        {
            var command = new DeleteSupplierCommand(id , true);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return NotFound(result);
            return NoContent();
        }
    }
}
