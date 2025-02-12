using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.VehicleTypes.Repositories;

public interface IVehicleTypeQueryRepository : IQueryRepository<long, VehicleType>
{
}