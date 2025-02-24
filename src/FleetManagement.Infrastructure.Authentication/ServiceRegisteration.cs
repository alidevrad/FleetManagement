using FleetManagement.Infrastructure.Authentication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Infrastructure.Authentication;

public static class ServiceRegisteration
{
    public static void SetupInfrastructureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthService>();
    }
}
