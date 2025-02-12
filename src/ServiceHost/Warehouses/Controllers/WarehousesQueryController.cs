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

    /// <summary>
    /// Get a warehouse by ID.
    /// </summary>
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Warehouse>> GetById(long id)
    {
        var warehouse = await _mediator.Send(new GetWarehouseByIdQuery(id));
        return warehouse != null ? Ok(warehouse) : NotFound();
    }

    /// <summary>
    /// Get all warehouses.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<Warehouse>>> GetAll()
    {
        var warehouses = await _mediator.Send(new GetAllWarehousesQuery());
        return Ok(warehouses);
    }

    /// <summary>
    /// Find warehouses by filter.
    /// Example usage: /api/WarehouseQuery/find?city=NewYork
    /// </summary>
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
