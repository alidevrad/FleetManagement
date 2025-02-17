using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Resources.Commands;

public record RollbackResourceReservationCommand(long ResourceId, Guid BusinessId) : ICommand;
