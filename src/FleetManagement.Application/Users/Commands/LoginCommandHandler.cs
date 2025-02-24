using FleetManagement.Application.Contract.Users.Commands;
using FleetManagement.Infrastructure.Authentication.Services;
using MediatR;

namespace FleetManagement.Application.Users.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.Login(request.UserName,
                                              request.Password);

        if (!result.Success) throw new UnauthorizedAccessException(result.Message);

        return result.Token;
    }
}

