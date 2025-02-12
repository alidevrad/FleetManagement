using FleetManagement.Domain.Models.VehicleTypes;
using MediatR;

namespace FleetManagement.Application.Contract.VehicleTypes.Queries;

public record GetVehicleTypeByIdQuery(long Id) : IRequest<VehicleType>;

