using FleetManagement.Application.Contract.Warehouses.Commands;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Commands;

public class ActivateWarehouseCommandHandler : IRequestHandler<ActivateWarehouseCommand>
{
    private readonly IWarehouseCommandRepository _commandRepository;
    private readonly IWarehouseQueryRepository _queryRepository;

    public ActivateWarehouseCommandHandler(IWarehouseCommandRepository commandRepository,
                                             IWarehouseQueryRepository queryRepository)
    {
        this._commandRepository = commandRepository;
        this._queryRepository = queryRepository;
    }

    public async Task Handle(ActivateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _queryRepository.GetByIdAsync(request.Id);
        if (warehouse == null)
        {
            throw new KeyNotFoundException("Warehouse not found");
        }

        warehouse.Activate();

        _commandRepository.Update(warehouse);
        await _commandRepository.SaveChangesAsync();
    }
}

