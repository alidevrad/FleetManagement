using FleetManagement.Application.Contract.Warehouses.Commands;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Commands;

public class DeactivateWarehouseCommandHandler : IRequestHandler<DeactivateWarehouseCommand>
{
    private readonly IWarehouseCommandRepository _commandRepository;
    private readonly IWarehouseQueryRepository _queryRepository;

    public DeactivateWarehouseCommandHandler(IWarehouseCommandRepository commandRepository,
                                             IWarehouseQueryRepository queryRepository)
    {
        this._commandRepository = commandRepository;
        this._queryRepository = queryRepository;
    }

    public async Task Handle(DeactivateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _queryRepository.GetByIdAsync(request.Id);
        if (warehouse == null)
        {
            throw new KeyNotFoundException("Warehouse not found");
        }

        warehouse.Deactivate();

        _commandRepository.Update(warehouse);
        await _commandRepository.SaveChangesAsync();
    }
}