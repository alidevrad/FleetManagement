using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Warehouses.Repositories;

public interface IWarehouseCommandRepository : ICommandRepository<long, Warehouse>
{
}
