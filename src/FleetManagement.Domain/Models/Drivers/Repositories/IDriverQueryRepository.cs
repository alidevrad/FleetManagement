using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Drivers.Repositories;

public interface IDriverQueryRepository : IQueryRepository<long, Driver>
{
}