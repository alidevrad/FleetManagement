using FleetManagement.Application.Contract.Drivers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceHost.Drivers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly IMediator _mediator;

    public DriversController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDriverCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateDriverCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched driver ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteDriverCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/activate")]
    public async Task<IActionResult> Activate(long id)
    {
        await _mediator.Send(new ActivateDriverCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(long id)
    {
        await _mediator.Send(new DeactivateDriverCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/add-emergency-contact")]
    public async Task<IActionResult> AddEmergencyContact(long id, [FromBody] AddEmergencyContactCommand command)
    {
        if (id != command.DriverId)
            return BadRequest("Mismatched driver ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/add-training-qualification")]
    public async Task<IActionResult> AddTrainingQualification(long id, [FromBody] AddTrainingQualificationCommand command)
    {
        if (id != command.DriverId)
            return BadRequest("Mismatched driver ID");

        await _mediator.Send(command);
        return NoContent();
    }

    #region Next phase

    //TODO: Next phase

    //[HttpPost("{id}/reserve")]
    //public async Task<IActionResult> Reserve(long id, [FromBody] ReserveDriverCommand command)
    //{
    //    if (id != command.Id)
    //        return BadRequest("Mismatched driver ID");

    //    await _mediator.Send(command);
    //    return NoContent();
    //}

    //[HttpPost("{id}/release")]
    //public async Task<IActionResult> Release(long id, [FromBody] ReleaseDriverFromReservationCommand command)
    //{
    //    if (id != command.Id)
    //        return BadRequest("Mismatched driver ID");

    //    await _mediator.Send(command);
    //    return NoContent();
    //}

    #endregion
}

