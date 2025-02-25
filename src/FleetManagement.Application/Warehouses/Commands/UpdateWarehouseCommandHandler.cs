using FleetManagement.Application.Contract.Warehouses.Commands;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Commands;

public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand>
{
    private readonly IWarehouseCommandRepository _commandRepository;
    private readonly IWarehouseQueryRepository _queryRepository;

    public UpdateWarehouseCommandHandler(IWarehouseCommandRepository commandRepository,
                                         IWarehouseQueryRepository queryRepository)
    {
        this._commandRepository = commandRepository;
        this._queryRepository = queryRepository;
    }

    public async Task Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _queryRepository.GetByIdAsync(request.Id);
        if (warehouse == null) throw new KeyNotFoundException("Warehouse not found");

        warehouse.Update(request.Name,
                         request.Street,
                         request.City,
                         request.State,
                         request.PostalCode,
                         request.Country,
                         request.PhoneNumber,
                         request.Email,
                         request.Latitude,
                         request.Longitude);

        _commandRepository.Update(warehouse);
        await _commandRepository.SaveChangesAsync();
    }
}
