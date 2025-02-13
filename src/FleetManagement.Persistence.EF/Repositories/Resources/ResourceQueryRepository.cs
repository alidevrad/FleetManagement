using FleetManagement.Domain.Models.Resources;
using FleetManagement.Domain.Models.Resources.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Resources;

public class ResourceQueryRepository : BaseQueryRepository<long, Resource>, IResourceQueryRepository
{
    public ResourceQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
