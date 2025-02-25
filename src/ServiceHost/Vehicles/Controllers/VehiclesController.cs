using FleetManagement.Application.Contract.Vehicles.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceHost.Vehicles.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehicleCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateVehicleCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched vehicle ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteVehicleCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/activate")]
    public async Task<IActionResult> Activate(long id)
    {
        await _mediator.Send(new ActivateVehicleCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(long id)
    {
        await _mediator.Send(new DeactivateVehicleCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/add-maintenance")]
    public async Task<IActionResult> AddMaintenance(long id, [FromBody] AddVehicleMaintenanceCommand command)
    {
        if (id != command.VehicleId)
            return BadRequest("Mismatched vehicle ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{vehicleId}/update-maintenance/{maintenanceId}")]
    public async Task<IActionResult> UpdateVehicleMaintenance(long vehicleId, long maintenanceId, [FromBody] UpdateVehicleMaintenanceCommand command)
    {
        if (vehicleId != command.Id || maintenanceId != command.VehicleMaintenanceId)
            return BadRequest("Mismatched vehicle or maintenance ID");

        await _mediator.Send(command);
        return NoContent();
    }

    #region Next phase

    //TODO: Next phase

    //[HttpPost("{id}/reserve")]
    //public async Task<IActionResult> Reserve(long id, [FromBody] ReserveVehicleCommand command)
    //{
    //    if (id != command.Id)
    //        return BadRequest("Mismatched vehicle ID");

    //    await _mediator.Send(command);
    //    return NoContent();
    //}

    //[HttpPost("{id}/release")]
    //public async Task<IActionResult> Release(long id, [FromBody] ReleaseVehicleFromReservationCommand command)
    //{
    //    if (id != command.Id)
    //        return BadRequest("Mismatched vehicle ID");

    //    await _mediator.Send(command);
    //    return NoContent();
    //}

    #endregion
}