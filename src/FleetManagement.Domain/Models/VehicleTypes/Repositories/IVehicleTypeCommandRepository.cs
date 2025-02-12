using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.VehicleTypes.Repositories;

public interface IVehicleTypeCommandRepository : ICommandRepository<long, VehicleType>
{
}
