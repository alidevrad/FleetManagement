using FleetManagement.Domain.Models.Drivers;
using MediatR;

namespace FleetManagement.Application.Contract.Drivers.Queries;

public record GetDriverByIdQuery(long Id) : IRequest<Driver>;
