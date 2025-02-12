using FleetManagement.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using ServiceHost;
using ServiceHost.Common.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterBuiltInServices();

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
    });
}

app.UseGlobalExceptionHandling();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
