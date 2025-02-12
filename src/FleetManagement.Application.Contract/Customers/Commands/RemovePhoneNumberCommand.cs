using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record RemovePhoneNumberCommand(long CustomerId, string Number) : ICommand;