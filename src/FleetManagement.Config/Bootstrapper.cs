using FleetManagement.Application;
using FleetManagement.Infrastructure;
using FleetManagement.Infrastructure.Authentication;
using FleetManagement.Persistence.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Config;

public class Bootstrapper
{
    public static void WireUpModule(IServiceCollection services, IConfiguration configuration)
    {
        services.SetupPersistence(configuration);

        services.SetupInfrastructure(configuration);

        services.SetupInfrastructureAuthentication(configuration);

        services.SetupApplicaiton();
    }
}
