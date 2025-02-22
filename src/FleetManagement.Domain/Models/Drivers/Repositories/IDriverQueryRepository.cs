using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Drivers.Repositories;

public interface IDriverQueryRepository : IQueryRepository<long, Driver>
{
}

//TODO: Next phase
//public interface IDriverQueryRepository : IQueryRepository<long, Driver>
//{
//    // Check if a driver is available for a specific period
//    Task<bool> IsDriverAvailable(long driverId, DateTime startDateTime, DateTime endDateTime);

//    // Get drivers available at this exact moment
//    Task<List<Driver>> GetAvailableDriversForNow();

//    // Get drivers available for a specific time period
//    Task<List<Driver>> GetAvailableDriversForPeriod(DateTime startDateTime, DateTime endDateTime);

//    // Get drivers available for the next hour
//    Task<List<Driver>> GetAvailableDriversForNextHour(DateTime startDateTime);
//}