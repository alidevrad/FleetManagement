using FleetManagement.Domain.Common.BuildingBlocks.Events;
using FleetManagement.Infrastructure.GoogleMaps;
using FleetManagement.Infrastructure.Messaging.EventPublisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Infrastructure;

public static class ServiceRegisteration
{
    public static void SetupInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterGoogleMapService(services);

        RegisterMediatREventPublisher(services);
    }

    private static void RegisterGoogleMapService(this IServiceCollection services)
    {
        services.AddScoped<IGoogleMapService, GoogleMapService>();
    }

    private static void RegisterMediatREventPublisher(this IServiceCollection services)
    {
        services.AddScoped<IEventPublisher, MediatorEventPublisher>();
    }
}
