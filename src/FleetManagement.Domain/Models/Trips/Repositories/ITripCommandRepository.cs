using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Trips.Repositories;

public interface ITripCommandRepository : ICommandRepository<long, Trip>
{
}
