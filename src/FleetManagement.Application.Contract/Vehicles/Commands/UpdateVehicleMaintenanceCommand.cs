using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record UpdateVehicleMaintenanceCommand(
        long Id,
        long VehicleMaintenanceId,
        string Reason
    ) : ICommand;