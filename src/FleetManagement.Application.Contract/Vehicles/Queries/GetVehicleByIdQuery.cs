using FleetManagement.Domain.Models.Vehicles;
using MediatR;

namespace FleetManagement.Application.Contract.Vehicles.Queries;

public record GetVehicleByIdQuery(long Id) : IRequest<Vehicle>;
