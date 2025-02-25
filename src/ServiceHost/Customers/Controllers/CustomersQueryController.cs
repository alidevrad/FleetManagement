using FleetManagement.Application.Contract.Customers.Queries;
using FleetManagement.Domain.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.Customers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersQueryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomersQueryController(IMediator mediator)
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

    [HttpGet("{id:long}/branches")]
    public async Task<ActionResult<List<Branch>>> GetBranchesByCustomerId(long id)
    {
        var branches = await _mediator.Send(new GetCustomerBranchesQuery(id));
        return branches != null && branches.Count > 0 ? Ok(branches) : NotFound();
    }

    [HttpGet("{customerId:long}/branches/{branchId:long}")]
    public async Task<ActionResult<Branch>> GetSpecificBranchOfCustomer(long customerId, long branchId)
    {
        var branch = await _mediator.Send(new GetSpecificBranchOfCustomerQuery(customerId, branchId));
        return branch != null ? Ok(branch) : NotFound();
    }
}
