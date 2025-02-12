using FleetManagement.Application.Contract.VehicleTypes.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.VehicleTypes.Commands;

public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommand>
{
    private readonly IVehicleCommandRepository _commandRepository;
    private readonly IVehicleQueryRepository _queryRepository;

    public DeleteVehicleTypeCommandHandler(IVehicleCommandRepository commandRepository,
                                           IVehicleQueryRepository queryRepository)
    {
        this._commandRepository = commandRepository;
        this._queryRepository = queryRepository;
    }

    public async Task Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = await _queryRepository.GetByIdAsync(request.Id);
        if (vehicleType == null) throw new KeyNotFoundException("VehicleType not found");

        _commandRepository.Delete(vehicleType);
        await _commandRepository.SaveChangesAsync();
    }
}
