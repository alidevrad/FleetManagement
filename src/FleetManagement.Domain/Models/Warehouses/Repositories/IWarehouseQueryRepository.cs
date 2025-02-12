using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Warehouses.Repositories;

public interface IWarehouseQueryRepository : IQueryRepository<long, Warehouse>
{
}