using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Resources.Repositories;

public interface IResourceCommandRepository : ICommandRepository<long, Resource>
{
    Task<Resource> LockResource(long resourceId, string resourceType, DateTime startDateTime, DateTime endDateTime);
    Task<bool> IsResourceLocked(long resourceId, string resourceType, DateTime startDateTime);
    Task ReleaseResource(long resourceId, string resourceType);
}
