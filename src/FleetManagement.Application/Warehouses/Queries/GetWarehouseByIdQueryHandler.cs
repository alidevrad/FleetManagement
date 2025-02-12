using FleetManagement.Application.Contract.Warehouses.Queries;
using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Queries;

public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, Warehouse>
{
    private readonly IWarehouseQueryRepository _queryRepository;

    public GetWarehouseByIdQueryHandler(IWarehouseQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<Warehouse> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
    {
        var warehouse = await _queryRepository.GetByIdAsync(request.Id);
        if (warehouse == null)
        {
            throw new KeyNotFoundException("Warehouse not found");
        }

        return warehouse;
    }
}
