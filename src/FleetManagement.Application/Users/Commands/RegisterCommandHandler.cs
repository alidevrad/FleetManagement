using FleetManagement.Application.Contract.Users.Commands;
using FleetManagement.Infrastructure.Authentication.Services;
using MediatR;

namespace FleetManagement.Application.Users.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.Register(request.UserName,
                                                 request.FirstName,
                                                 request.LastName,
                                                 request.Email,
                                                 request.Password);

        if (!result.Success) throw new InvalidOperationException(result.Message);

        return true;
    }
}