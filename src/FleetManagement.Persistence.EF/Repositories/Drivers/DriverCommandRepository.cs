using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Drivers.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Drivers;

public class DriverCommandRepository : BaseCommandRepository<long, Driver>, IDriverCommandRepository
{
    public DriverCommandRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
