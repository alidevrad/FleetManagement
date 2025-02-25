using FleetManagement.Domain.Models.Vehicles;
using MediatR;

namespace FleetManagement.Application.Contract.Vehicles.Queries;

public record GetSpecificVehicleMaintenanceOfVehicleQuery(long VehicleId, long VehicleMaintenanceId) : IRequest<VehicleMaintenance>;

