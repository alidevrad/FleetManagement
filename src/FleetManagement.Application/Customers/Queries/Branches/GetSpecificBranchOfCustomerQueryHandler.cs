using FleetManagement.Application.Contract.Customers.Queries;
using FleetManagement.Domain.Models.Customers;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

public class GetSpecificBranchOfCustomerQueryHandler : IRequestHandler<GetSpecificBranchOfCustomerQuery, Branch>
{
    private readonly ICustomerQueryRepository _queryRepository;

    public GetSpecificBranchOfCustomerQueryHandler(ICustomerQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<Branch> Handle(GetSpecificBranchOfCustomerQuery request, CancellationToken cancellationToken)
    {
        var branch = await _queryRepository.GetSpecificBranchOfCustomer(request.CustomerId, request.BranchId);

        if (branch == null) throw new KeyNotFoundException("Branch not found");

        return branch;
    }
}
