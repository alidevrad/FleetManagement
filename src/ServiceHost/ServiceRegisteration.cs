using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost;

public static class ServiceRegisteration
{
    public static void RegisterBuiltInServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                // Gather errors from ModelState into a list of objects with propertyName and errorMessage.
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
                    Detail = "One or more validation errors has occurred"
                };

                // Add the custom errors list to the Extensions dictionary.
                problemDetails.Extensions["errors"] = errors;

                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/json" }
                };
            };
        });
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            var apiGroups = new Dictionary<string, string>
            {
                { "drivers", "Drivers API" },
                { "vehicles", "Vehicles API" },
                { "vehicleTypes", "VehicleTypes API" },
                { "warehouses", "Warehouses API" },
                { "customers", "Customers API" }
            };

            foreach (var group in apiGroups)
            {
                c.SwaggerDoc(group.Key, new OpenApiInfo { Title = group.Value, Version = "v1" });
            }

            c.DocInclusionPredicate((docName, apiDesc) =>
                apiDesc.ActionDescriptor.RouteValues.TryGetValue("controller", out var controllerName) &&
                apiGroups.Keys.Any(group => docName == group && controllerName!.StartsWith(group, StringComparison.OrdinalIgnoreCase))
            );
        });
    }
}
