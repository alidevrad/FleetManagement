using FleetManagement.Config;
using FleetManagement.Infrastructure.Authentication.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceHost;
using ServiceHost.Common.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthConfig>(builder.Configuration.GetSection("AuthConfig"));

builder.Services.RegisterBuiltInServices(builder.Configuration);

Bootstrapper.WireUpModule(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/drivers/swagger.json", "Drivers API");
        c.SwaggerEndpoint("/swagger/vehicles/swagger.json", "Vehicles API");
        c.SwaggerEndpoint("/swagger/vehicleTypes/swagger.json", "VehicleTypes API");
        c.SwaggerEndpoint("/swagger/warehouses/swagger.json", "Warehouses API");
        c.SwaggerEndpoint("/swagger/customers/swagger.json", "Customers API");
        c.SwaggerEndpoint("/swagger/trips/swagger.json", "Trips API");
        c.SwaggerEndpoint("/swagger/users/swagger.json", "Users API");
    });
}

app.UseGlobalExceptionHandling();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
