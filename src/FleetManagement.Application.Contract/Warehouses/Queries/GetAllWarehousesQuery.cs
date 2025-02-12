using FleetManagement.Domain.Models.Warehouses;
using MediatR;

namespace FleetManagement.Application.Contract.Warehouses.Queries;

public record GetAllWarehousesQuery() : IRequest<List<Warehouse>>;