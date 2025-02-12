using FleetManagement.Application.Contract.Customers.Queries;
using FleetManagement.Domain.Models.Customers;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Queries;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerQueryRepository _queryRepository;

    public GetCustomerByIdQueryHandler(ICustomerQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _queryRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }
        return customer;
    }
}
