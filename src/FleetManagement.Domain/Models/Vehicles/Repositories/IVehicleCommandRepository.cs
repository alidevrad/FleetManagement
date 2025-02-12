using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Vehicles.Repositories;

public interface IVehicleCommandRepository : ICommandRepository<long, Vehicle>
{
}
