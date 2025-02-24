using FleetManagement.Infrastructure.Authentication.DTOS;

namespace FleetManagement.Infrastructure.Authentication.Services;

public interface IAuthService
{
    Task<AuthResult> Register(string userName, string firstName, string lastName, string email, string password);
    Task<AuthResult> Login(string userName, string password);
}
