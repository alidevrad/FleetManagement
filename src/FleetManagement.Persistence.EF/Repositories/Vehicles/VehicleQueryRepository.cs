using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using FleetManagement.Persistence.EF.DbContextes;
using FleetManagement.Persistence.EF.Repositories;
using Microsoft.EntityFrameworkCore;

public class VehicleQueryRepository : BaseQueryRepository<long, Vehicle>, IVehicleQueryRepository
{
    public VehicleQueryRepository(FleetManagementDbContext context) : base(context) { }

    public async Task<bool> IsVehicleAvailable(long vehicleId, DateTime startDateTime, DateTime endDateTime)
    {
        var vehicle = await _dbSet.Include(v => v.ReservationPeriods)
                                  .FirstOrDefaultAsync(v => v.Id == vehicleId);

        if (vehicle == null) return false;

        return vehicle.IsAvailableForPeriod(startDateTime, endDateTime);
    }

    public async Task<List<Vehicle>> GetAvailableVehiclesForNow()
    {
        var now = DateTime.UtcNow;

        return await _dbSet.Where(v => v.IsAvailableForPeriod(now, now.AddMinutes(1)))
                           .ToListAsync();
    }

    public async Task<List<Vehicle>> GetAvailableVehiclesForPeriod(DateTime startDateTime, DateTime endDateTime)
    {
        return await _dbSet.Where(v => v.IsAvailableForPeriod(startDateTime, endDateTime))
                           .ToListAsync();
    }

    public async Task<List<Vehicle>> GetAvailableVehiclesForNextHour(DateTime startDateTime)
    {
        return await GetAvailableVehiclesForPeriod(startDateTime, startDateTime.AddHours(1));
    }
}
