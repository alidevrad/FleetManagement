using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class ReleaseVehicleCommandHandler : IRequestHandler<ReleaseVehicleCommand>
{
    private readonly IVehicleCommandRepository _vehicleRepository;
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public ReleaseVehicleCommandHandler(
        IVehicleCommandRepository vehicleRepository,
        IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task Handle(ReleaseVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleQueryRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
            throw new KeyNotFoundException("Vehicle not found.");

        vehicle.Release();
        _vehicleRepository.Update(vehicle);
        await _vehicleRepository.SaveChangesAsync();
    }
}
