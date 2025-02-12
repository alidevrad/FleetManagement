using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class AddVehicleMaintenanceCommandHandler : IRequestHandler<AddVehicleMaintenanceCommand>
{
    private readonly IVehicleCommandRepository _vehicleRepository;
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public AddVehicleMaintenanceCommandHandler(
        IVehicleCommandRepository vehicleRepository,
        IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task Handle(AddVehicleMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleQueryRepository.GetByIdAsync(request.VehicleId);
        if (vehicle == null)
            throw new KeyNotFoundException("Vehicle not found.");

        vehicle.AddMaintenanceRecord(request.Reason, request.RepairDate);
        _vehicleRepository.Update(vehicle);
        await _vehicleRepository.SaveChangesAsync();
    }
}
