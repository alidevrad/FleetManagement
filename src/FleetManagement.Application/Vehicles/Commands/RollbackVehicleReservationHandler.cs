using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class RollbackVehicleReservationHandler : IRequestHandler<RollbackVehicleReservationCommand>
{
    private readonly IVehicleQueryRepository _vehicleQueryRepository;
    private readonly IVehicleCommandRepository _commandRepository;

    public RollbackVehicleReservationHandler(IVehicleQueryRepository vehicleRepository,
                                             IVehicleCommandRepository commandRepository)
    {
        this._vehicleQueryRepository = vehicleRepository;
        this._commandRepository = commandRepository;
    }

    public async Task Handle(RollbackVehicleReservationCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleQueryRepository.GetByIdAsync(command.VehicleId);
        if (vehicle == null)
            throw new InvalidOperationException("Vehicle not found.");

        vehicle.Release(command.ReservationId);

        _commandRepository.Update(vehicle);
        await _commandRepository.SaveChangesAsync();
    }
}
