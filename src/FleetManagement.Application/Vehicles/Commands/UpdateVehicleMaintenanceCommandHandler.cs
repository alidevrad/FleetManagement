using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class UpdateVehicleMaintenanceCommandHandler : IRequestHandler<UpdateVehicleMaintenanceCommand>
{
    private readonly IVehicleQueryRepository _vehicleQueryRepository;
    private readonly IVehicleCommandRepository _commandRepository;

    public UpdateVehicleMaintenanceCommandHandler(IVehicleQueryRepository vehicleQueryRepository, IVehicleCommandRepository commandRepository)
    {
        this._vehicleQueryRepository = vehicleQueryRepository;
        this._commandRepository = commandRepository;
    }

    public async Task Handle(UpdateVehicleMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleQueryRepository.GetByIdAsync(request.Id);
        if (vehicle is null)
            throw new Exception($"Vehicle with ID {request.Id} not found.");

        var vehicleMaintenance = vehicle.VehicleMaintenances.FirstOrDefault(b => b.Id == request.VehicleMaintenanceId);
        if (vehicleMaintenance is null)
            throw new Exception($"VehicleMaintenance with ID {request.VehicleMaintenanceId} not found for Vehicle {request.Id}.");

        vehicleMaintenance.Update(request.Reason);

        _commandRepository.Update(vehicle);
        await _commandRepository.SaveChangesAsync();
    }
}
