using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record ReleaseDriverCommand(long Id) : ICommand;
