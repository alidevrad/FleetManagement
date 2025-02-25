using FleetManagement.Domain.Models.Vehicles;
using MediatR;

namespace FleetManagement.Application.Contract.Vehicles.Queries;

public record GetVehicleMaintenancesQuery(long VehicleId) : IRequest<List<VehicleMaintenance>>;
