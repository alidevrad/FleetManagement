using FleetManagement.Domain.Common.BuildingBlocks.Core;

namespace FleetManagement.Domain.Models.Resources;

public class Resource : AuditableAggregateRoot<long>
{
    public long ResourceId { get; private set; }
    public string ResourceType { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public bool IsLocked { get; private set; }

    protected Resource() : base(Guid.NewGuid()) { }

    public Resource(long resourceId,
                       string resourceType,
                       DateTime startDateTime,
                       DateTime endDateTime,
                       Guid businessId)
        : base(businessId)
    {
        ResourceId = resourceId;
        ResourceType = resourceType;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsLocked = true;
    }

    public void Lock()
    {
        if (IsLocked)
            throw new InvalidOperationException("Resource  is already locked.");
        IsLocked = true;
    }

    public void Release()
    {
        if (!IsLocked)
            throw new InvalidOperationException("Resource  is already released.");
        IsLocked = false;
    }
}
