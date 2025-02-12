using FleetManagement.Application.Contract.Warehouses.Queries;
using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Queries;

public class FindWarehousesQueryHandler : IRequestHandler<FindWarehousesQuery, List<Warehouse>>
{
    private readonly IWarehouseQueryRepository _queryRepository;

    public FindWarehousesQueryHandler(IWarehouseQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<List<Warehouse>> Handle(FindWarehousesQuery request, CancellationToken cancellationToken)
    {
        return await _queryRepository.FindAsync(request.Predicate);
    }
}