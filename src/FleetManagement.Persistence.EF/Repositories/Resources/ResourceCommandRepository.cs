using FleetManagement.Domain.Models.Resources;
using FleetManagement.Domain.Models.Resources.Repositories;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FleetManagement.Persistence.EF.Repositories.Resources;

public class ResourceCommandRepository : BaseCommandRepository<long, Resource>, IResourceCommandRepository
{
    public ResourceCommandRepository(FleetManagementDbContext context) : base(context) { }

    public async Task<bool> LockResource(long resourceId, string resourceType, DateTime startDateTime, DateTime endDateTime)
    {
        var strategy = _context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);

            var existingReservation = await _dbSet
                .FirstOrDefaultAsync(r => r.ResourceId == resourceId &&
                                          r.ResourceType == resourceType &&
                                          r.StartDateTime < endDateTime &&
                                          r.EndDateTime > startDateTime &&
                                          r.IsLocked);

            if (existingReservation != null)
            {
                return false; // ❌ Resource is already locked
            }

            var reservation = new Resource(resourceId, resourceType, startDateTime, endDateTime, Guid.NewGuid());
            await _dbSet.AddAsync(reservation);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return true;
        });
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
