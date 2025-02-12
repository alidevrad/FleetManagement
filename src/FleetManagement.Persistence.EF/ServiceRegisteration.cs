using FleetManagement.Domain.Common.Repositories.Commands;
using FleetManagement.Domain.Common.Repositories.Queries;
using FleetManagement.Persistence.EF.DbContextes;
using FleetManagement.Persistence.EF.Repositories;
using FleetManagement.Persistence.EF.Repositories.Warehouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Persistence.EF;

public static class ServiceRegisteration
{
    public static void SetupPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDbContext(services, configuration);

        RegisterRepositories(services);
    }
    private static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<FleetManagementDbContext>(option =>
        {
            var connectionString = configuration.GetConnectionString("DbConnection");

            option.UseSqlServer(
                connectionString: connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
        });
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddScoped(typeof(ICommandRepository<,>), typeof(BaseCommandRepository<,>));

        services.Scan(scan => scan
           .FromAssemblyOf<WarehouseCommandRepository>()
           .AddClasses(classes => classes.AssignableTo(typeof(ICommandRepository<,>)))
           .AsImplementedInterfaces()
           .WithScopedLifetime());

        services.AddScoped(typeof(IQueryRepository<,>), typeof(BaseQueryRepository<,>));

        services.Scan(scan => scan
           .FromAssemblyOf<WarehouseQueryRepository>()
           .AddClasses(classes => classes.AssignableTo(typeof(IQueryRepository<,>)))
           .AsImplementedInterfaces()
           .WithScopedLifetime());
    }

}
