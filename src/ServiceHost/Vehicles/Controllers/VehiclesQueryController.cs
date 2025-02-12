using FleetManagement.Application.Contract.Vehicles.Queries;
using FleetManagement.Domain.Models.Vehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.Vehicles.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Vehicle>> GetById(long id)
    {
        var vehicle = await _mediator.Send(new GetVehicleByIdQuery(id));
        return vehicle != null ? Ok(vehicle) : NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> GetAll()
    {
        var vehicles = await _mediator.Send(new GetAllVehiclesQuery());
        return Ok(vehicles);
    }

}