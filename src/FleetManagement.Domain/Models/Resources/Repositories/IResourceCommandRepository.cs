using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Resources.Repositories;

public interface IResourceCommandRepository : ICommandRepository<long, Resource>
{
    Task<bool> LockResource(long resourceId, string resourceType, DateTime startDateTime, DateTime endDateTime);
    Task ReleaseResource(long resourceId, string resourceType);
}
