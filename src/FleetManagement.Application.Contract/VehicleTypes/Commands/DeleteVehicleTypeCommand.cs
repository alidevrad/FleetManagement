using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.VehicleTypes.Commands;

public record DeleteVehicleTypeCommand(long Id) : ICommand;
