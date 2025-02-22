using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Vehicles.Repositories;

public interface IVehicleQueryRepository : IQueryRepository<long, Vehicle>
{
}

//TODO: Next phase
//public interface IVehicleQueryRepository : IQueryRepository<long, Vehicle>
//{
//    // Check if a vehicle is available for a specific period
//    Task<bool> IsVehicleAvailable(long vehicleId, DateTime startDateTime, DateTime endDateTime);

//    // Get vehicles available at this exact moment
//    Task<List<Vehicle>> GetAvailableVehiclesForNow();

//    // Get vehicles available for a specific time period
//    Task<List<Vehicle>> GetAvailableVehiclesForPeriod(DateTime startDateTime, DateTime endDateTime);

//    // Get vehicles available for the next hour
//    Task<List<Vehicle>> GetAvailableVehiclesForNextHour(DateTime startDateTime);
//}
