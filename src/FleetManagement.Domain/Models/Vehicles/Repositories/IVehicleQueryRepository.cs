using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Vehicles.Repositories;

public interface IVehicleQueryRepository : IQueryRepository<long, Vehicle>
{ }
