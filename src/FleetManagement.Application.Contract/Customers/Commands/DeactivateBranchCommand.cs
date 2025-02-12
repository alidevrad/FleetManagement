using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record DeactivateBranchCommand(long CustomerId, long BranchId) : ICommand;
