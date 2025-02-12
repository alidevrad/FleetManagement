using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Drivers.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Drivers;

public class DriverQueryRepository : BaseQueryRepository<long, Driver>, IDriverQueryRepository
{
    public DriverQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
