using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record DeleteCustomerCommand(long Id) : ICommand;
