using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Trips.Repositories;

public interface ITripQueryRepository : IQueryRepository<long, Trip>
{
}
