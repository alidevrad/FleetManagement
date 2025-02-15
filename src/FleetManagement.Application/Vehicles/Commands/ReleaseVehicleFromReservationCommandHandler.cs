using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class ReleaseVehicleFromReservationCommandHandler : IRequestHandler<ReleaseVehicleFromReservationCommand>
{
    private readonly IVehicleCommandRepository _vehicleRepository;
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public ReleaseVehicleFromReservationCommandHandler(
        IVehicleCommandRepository vehicleRepository,
        IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task Handle(ReleaseVehicleFromReservationCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleQueryRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
            throw new KeyNotFoundException("Vehicle not found.");

        vehicle.Release(request.ReservationId);
        _vehicleRepository.Update(vehicle);

        await _vehicleRepository.SaveChangesAsync();
    }
}
