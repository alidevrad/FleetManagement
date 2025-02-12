using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record ActivateBranchCommand(long CustomerId, long BranchId) : ICommand;
