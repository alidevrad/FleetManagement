using FleetManagement.Domain.Models.Customers;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Queries.Branches;

public class GetCustomerBranchesQueryHandler : IRequestHandler<GetCustomerBranchesQuery, List<Branch>>
{
    private readonly ICustomerQueryRepository _queryRepository;

    public GetCustomerBranchesQueryHandler(ICustomerQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<List<Branch>> Handle(GetCustomerBranchesQuery request, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetBranchesByCustomerId(request.CustomerId);
    }
}
