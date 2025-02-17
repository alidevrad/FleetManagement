using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Resources.Commands;

public record ReleaseResourceCommand(long ResourceId, string ResourceType) : ICommand;
