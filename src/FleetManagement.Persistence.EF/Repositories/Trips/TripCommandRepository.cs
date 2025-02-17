using FleetManagement.Domain.Models.Trips;
using FleetManagement.Domain.Models.Trips.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Trips;

public class TripCommandRepository : BaseCommandRepository<long, Trip>, ITripCommandRepository
{
    public TripCommandRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
