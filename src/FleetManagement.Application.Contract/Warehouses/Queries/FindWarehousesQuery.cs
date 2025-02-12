using FleetManagement.Domain.Models.Warehouses;
using MediatR;
using System.Linq.Expressions;

namespace FleetManagement.Application.Contract.Warehouses.Queries;

public record FindWarehousesQuery(Expression<Func<Warehouse, bool>> Predicate) : IRequest<List<Warehouse>>;