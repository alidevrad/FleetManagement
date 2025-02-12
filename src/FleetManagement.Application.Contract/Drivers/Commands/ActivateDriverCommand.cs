using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record ActivateDriverCommand(long Id) : ICommand;
