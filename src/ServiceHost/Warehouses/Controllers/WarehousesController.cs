using FleetManagement.Application.Contract.Warehouses.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceHost.Warehouses.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehousesController : ControllerBase
{
    private readonly IMediator _mediator;

    public WarehousesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWarehouseCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateWarehouseCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched warehouse ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteWarehouseCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(long id)
    {
        await _mediator.Send(new DeactivateWarehouseCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/activate")]
    public async Task<IActionResult> Activate(long id)
    {
        await _mediator.Send(new ActivateWarehouseCommand(id));
        return NoContent();
    }
}