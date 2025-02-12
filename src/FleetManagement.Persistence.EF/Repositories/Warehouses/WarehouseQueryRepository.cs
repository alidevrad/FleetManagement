using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Warehouses;

public class WarehouseQueryRepository : BaseQueryRepository<long, Warehouse>, IWarehouseQueryRepository
{
    public WarehouseQueryRepository(FleetManagementDbContext context)
        : base(context)
    {
    }
}