using FleetManagement.Application.Contract.Warehouses.Commands;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Commands;

public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand>
{
    private readonly IWarehouseCommandRepository _commandRepository;
    private readonly IWarehouseQueryRepository _queryRepository;

    public DeleteWarehouseCommandHandler(IWarehouseCommandRepository commandRepository,
                                         IWarehouseQueryRepository queryRepository)
    {
        this._commandRepository = commandRepository;
        this._queryRepository = queryRepository;
    }

    public async Task Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _queryRepository.GetByIdAsync(request.Id);
        if (warehouse == null)
        {
            throw new KeyNotFoundException("Warehouse not found");
        }

        _commandRepository.Delete(warehouse);
        await _commandRepository.SaveChangesAsync();
    }
}
