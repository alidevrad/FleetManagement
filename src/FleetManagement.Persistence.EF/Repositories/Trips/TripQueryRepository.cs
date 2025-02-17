using FleetManagement.Domain.Models.Trips;
using FleetManagement.Domain.Models.Trips.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Trips;

public class TripQueryRepository : BaseQueryRepository<long, Trip>, ITripQueryRepository
{
    public TripQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
