using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Users.Commands;

public record LoginCommand(
    string UserName,
    string Password
) : ICommand<string>;

