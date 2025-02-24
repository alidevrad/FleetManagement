using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Common.Configurators;

public static class SwaggerServiceConfigurator
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            var apiGroups = new Dictionary<string, string>
            {
                { "drivers", "Drivers API" },
                { "vehicles", "Vehicles API" },
                { "vehicleTypes", "VehicleTypes API" },
                { "warehouses", "Warehouses API" },
                { "customers", "Customers API" },
                { "trips", "Trips API" },
                { "users", "Users API" }
            };

            foreach (var group in apiGroups)
            {
                c.SwaggerDoc(group.Key, new OpenApiInfo { Title = group.Value, Version = "v1" });
            }

            c.DocInclusionPredicate((docName, apiDesc) =>
                apiDesc.ActionDescriptor.RouteValues.TryGetValue("controller", out var controllerName) &&
                apiGroups.Keys.Any(group => docName == group && controllerName!.StartsWith(group, StringComparison.OrdinalIgnoreCase))
            );

            // تنظیمات احراز هویت در Swagger
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Enter 'Bearer {your token}'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                BearerFormat = "JWT",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            });
        });
    }
}

