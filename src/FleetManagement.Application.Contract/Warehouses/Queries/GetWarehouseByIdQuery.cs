using FleetManagement.Domain.Models.Warehouses;
using MediatR;

namespace FleetManagement.Application.Contract.Warehouses.Queries;

public record GetWarehouseByIdQuery(long Id) : IRequest<Warehouse>;
