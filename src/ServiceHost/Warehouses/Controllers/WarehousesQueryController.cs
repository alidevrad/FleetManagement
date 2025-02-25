using FleetManagement.Application.Contract.Warehouses.Queries;
using FleetManagement.Domain.Models.Warehouses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.Warehouses.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehousesQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public WarehousesQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Warehouse>> GetById(long id)
    {
        var warehouse = await _mediator.Send(new GetWarehouseByIdQuery(id));
        return warehouse != null ? Ok(warehouse) : NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<List<Warehouse>>> GetAll()
    {
        var warehouses = await _mediator.Send(new GetAllWarehousesQuery());
        return Ok(warehouses);
    }

    [HttpGet("find")]
    public async Task<ActionResult<List<Warehouse>>> Find([FromQuery] string? city, [FromQuery] string? state)
    {
        var warehouses = await _mediator.Send(new FindWarehousesQuery(w =>
            (string.IsNullOrEmpty(city) || w.City == city) &&
            (string.IsNullOrEmpty(state) || w.State == state)
        ));

        return Ok(warehouses);
    }
}
