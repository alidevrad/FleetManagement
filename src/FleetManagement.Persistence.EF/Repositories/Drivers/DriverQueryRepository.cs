using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Drivers.Repositories;
using FleetManagement.Persistence.EF.DbContextes;
using FleetManagement.Persistence.EF.Repositories;

public class DriverQueryRepository : BaseQueryRepository<long, Driver>, IDriverQueryRepository
{
    public DriverQueryRepository(FleetManagementDbContext context) : base(context) { }
}


//TODO: Next phase

//using FleetManagement.Domain.Models.Drivers;
//using FleetManagement.Domain.Models.Drivers.Repositories;
//using FleetManagement.Persistence.EF.DbContextes;
//using FleetManagement.Persistence.EF.Repositories;
//using Microsoft.EntityFrameworkCore;

//public class DriverQueryRepository : BaseQueryRepository<long, Driver>, IDriverQueryRepository
//{
//    public DriverQueryRepository(FleetManagementDbContext context) : base(context) { }

//    public async Task<bool> IsDriverAvailable(long driverId, DateTime startDateTime, DateTime endDateTime)
//    {
//        var driver = await _dbSet.Include(d => d.ReservationPeriods)
//                                 .FirstOrDefaultAsync(d => d.Id == driverId);

//        if (driver == null) return false;

//        return driver.IsAvailableForPeriod(startDateTime, endDateTime);
//    }

//    public async Task<List<Driver>> GetAvailableDriversForNow()
//    {
//        var now = DateTime.UtcNow;

//        return await _dbSet.Where(d => d.IsAvailableForPeriod(now, now.AddMinutes(1)))
//                           .ToListAsync();
//    }

//    public async Task<List<Driver>> GetAvailableDriversForPeriod(DateTime startDateTime, DateTime endDateTime)
//    {
//        return await _dbSet.Where(d => d.IsAvailableForPeriod(startDateTime, endDateTime))
//                           .ToListAsync();
//    }

//    public async Task<List<Driver>> GetAvailableDriversForNextHour(DateTime startDateTime)
//    {
//        return await GetAvailableDriversForPeriod(startDateTime, startDateTime.AddHours(1));
//    }
//}
