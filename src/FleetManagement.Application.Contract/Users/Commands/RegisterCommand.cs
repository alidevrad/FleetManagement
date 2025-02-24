using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Users.Commands;

public record RegisterCommand(
    string UserName,
    string FirstName,
    string LastName,
    string Email,
    string Password
) : ICommand<bool>;