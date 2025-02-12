using FleetManagement.Application.Contract.Drivers.Queries;
using FleetManagement.Domain.Models.Drivers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.Drivers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public DriversQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Driver>> GetById(long id)
    {
        var driver = await _mediator.Send(new GetDriverByIdQuery(id));
        return driver != null ? Ok(driver) : NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<List<Driver>>> GetAll()
    {
        var drivers = await _mediator.Send(new GetAllDriversQuery());
        return Ok(drivers);
    }
}
