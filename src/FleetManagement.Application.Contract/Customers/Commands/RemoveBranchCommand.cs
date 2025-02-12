using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record RemoveBranchCommand(long CustomerId, long BranchId) : ICommand;
