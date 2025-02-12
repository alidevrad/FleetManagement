using FleetManagement.Domain.Models.Vehicles;
using MediatR;

namespace FleetManagement.Application.Contract.Vehicles.Queries;

public record GetAllVehiclesQuery() : IRequest<List<Vehicle>>;
