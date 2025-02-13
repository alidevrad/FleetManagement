using FleetManagement.Domain.Models.Resources;
using FleetManagement.Domain.Models.Resources.Repositories;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Persistence.EF.Repositories.Resources;

public class ResourceCommandRepository : BaseCommandRepository<long, Resource>, IResourceCommandRepository
{
    public ResourceCommandRepository(FleetManagementDbContext context) : base(context) { }

    public async Task<Resource> LockResource(long resourceId, string resourceType, DateTime startDateTime, DateTime endDateTime)
    {
        var existingReservation = await _dbSet
            .FirstOrDefaultAsync(r => r.ResourceId == resourceId &&
                                      r.ResourceType == resourceType &&
                                      r.StartDateTime < endDateTime &&
                                      r.EndDateTime > startDateTime &&
                                      r.IsLocked);

        if (existingReservation != null)
        {
            return null; // ❌ قبلاً لاک شده است
        }

        var reservation = new Resource(resourceId, resourceType, startDateTime, endDateTime, Guid.NewGuid());
        await _dbSet.AddAsync(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }

    public async Task<bool> IsResourceLocked(long resourceId, string resourceType, DateTime startDateTime)
    {
        return await _dbSet
            .AnyAsync(r => r.ResourceId == resourceId &&
                           r.ResourceType == resourceType &&
                           r.StartDateTime <= startDateTime &&
                           r.EndDateTime >= startDateTime &&
                           r.IsLocked);
    }

    public async Task ReleaseResource(long resourceId, string resourceType)
    {
        var reservation = await _dbSet
            .FirstOrDefaultAsync(r => r.ResourceId == resourceId &&
                                      r.ResourceType == resourceType &&
                                      r.IsLocked);

        if (reservation != null)
        {
            reservation.Release();
            _dbSet.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }

}
