using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Drivers.Repositories;

public interface IDriverCommandRepository : ICommandRepository<long, Driver>
{
}
