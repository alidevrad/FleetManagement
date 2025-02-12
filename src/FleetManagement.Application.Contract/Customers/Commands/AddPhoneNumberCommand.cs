using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record AddPhoneNumberCommand(long CustomerId, string CountryCode, string Number, string Title) : ICommand;
