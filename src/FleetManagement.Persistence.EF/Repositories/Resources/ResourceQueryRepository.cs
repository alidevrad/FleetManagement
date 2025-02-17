using FleetManagement.Domain.Models.Resources;
using FleetManagement.Domain.Models.Resources.Repositories;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Persistence.EF.Repositories.Resources;

public class ResourceQueryRepository : BaseQueryRepository<long, Resource>, IResourceQueryRepository
{
    public ResourceQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }

    public async Task<Resource> GetByResourceIdAndBusinessIdAsync(long resourceId, Guid businessId)
    {
        return await _context.Resources
                             .FirstOrDefaultAsync(r => r.ResourceId == resourceId &&
                                                       r.BusinessId == businessId);
    }
}
