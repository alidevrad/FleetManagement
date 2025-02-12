using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record ReleaseVehicleCommand(long Id) : ICommand;