using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceHost.Common.Configurators;
using System.Linq;

namespace ServiceHost;

public static class ServiceRegistration
{
    public static void RegisterBuiltInServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.ConfigureAuthentication(configuration);
        services.ConfigureSwagger();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(e => e.Value.Errors.Select(error => new
                    {
                        propertyName = e.Key,
                        errorMessage = error.ErrorMessage
                    }))
                    .ToList();

                var problemDetails = new ProblemDetails
                {
                    Type = "ValidationFailure",
                    Title = "Validation error",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "One or more validation errors have occurred"
                };

                problemDetails.Extensions["errors"] = errors;

                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/json" }
                };
            };
        });

        services.AddEndpointsApiExplorer();
    }
}
