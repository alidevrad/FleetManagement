using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record AddVehicleMaintenanceCommand(
       long VehicleId,
       string Reason,
       DateTime RepairDate
   ) : ICommand;