using FleetManagement.Application.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FleetManagement.Application;

public static class ServiceRegisteration
{
    public static void SetupApplicaiton(this IServiceCollection services)
    {
        AddFluentValidation(services);

        AddMediatR(services);
    }

    private static void AddFluentValidation(IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private static void AddMediatR(IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
    }
}
