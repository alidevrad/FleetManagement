using FleetManagement.Application.Contract.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceHost.Customers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateCustomerCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched customer ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteCustomerCommand(id));
        return NoContent();
    }

    [HttpPost("{customerId}/add-branch")]
    public async Task<IActionResult> AddBranch(long customerId, [FromBody] AddBranchCommand command)
    {
        if (customerId != command.CustomerId)
            return BadRequest("Mismatched customer ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{customerId}/remove-branch/{branchId}")]
    public async Task<IActionResult> RemoveBranch(long customerId, long branchId)
    {
        await _mediator.Send(new RemoveBranchCommand(customerId, branchId));
        return NoContent();
    }

    [HttpPost("{customerId}/activate-branch/{branchId}")]
    public async Task<IActionResult> ActivateBranch(long customerId, long branchId)
    {
        await _mediator.Send(new ActivateBranchCommand(customerId, branchId));
        return NoContent();
    }

    [HttpPost("{customerId}/deactivate-branch/{branchId}")]
    public async Task<IActionResult> DeactivateBranch(long customerId, long branchId)
    {
        await _mediator.Send(new DeactivateBranchCommand(customerId, branchId));
        return NoContent();
    }

    [HttpPost("{customerId}/add-phone-number")]
    public async Task<IActionResult> AddPhoneNumber(long customerId, [FromBody] AddPhoneNumberCommand command)
    {
        if (customerId != command.CustomerId)
            return BadRequest("Mismatched customer ID");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{customerId}/remove-phone-number")]
    public async Task<IActionResult> RemovePhoneNumber(long customerId, [FromBody] RemovePhoneNumberCommand command)
    {
        if (customerId != command.CustomerId)
            return BadRequest("Mismatched customer ID");

        await _mediator.Send(command);
        return NoContent();
    }
}
