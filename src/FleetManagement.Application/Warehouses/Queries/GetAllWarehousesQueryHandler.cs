using FleetManagement.Application.Contract.Warehouses.Queries;
using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Queries;

public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, List<Warehouse>>
{
    private readonly IWarehouseQueryRepository _queryRepository;

    public GetAllWarehousesQueryHandler(IWarehouseQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<List<Warehouse>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetAllAsync();
    }
}
