using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Resources.Commands;

public record LockResourceCommand(long ResourceId,
                                  string ResourceType,
                                  DateTime StartDateTime,
                                  DateTime EndDateTime) : ICommand<bool>;