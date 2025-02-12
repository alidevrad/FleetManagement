using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record DeleteVehicleCommand(long Id) : ICommand;
