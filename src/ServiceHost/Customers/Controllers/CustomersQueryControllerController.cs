using FleetManagement.Application.Contract.Customers.Queries;
using FleetManagement.Domain.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.Customers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersQueryControllerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomersQueryControllerController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Customer>> GetById(long id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        return customer != null ? Ok(customer) : NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAll()
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(customers);
    }
}
