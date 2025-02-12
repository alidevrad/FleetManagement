using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Warehouses;

public class WarehouseCommandRepository : BaseCommandRepository<long, Warehouse>, IWarehouseCommandRepository
{
    public WarehouseCommandRepository(FleetManagementDbContext context)
        : base(context)
    {
    }
}
