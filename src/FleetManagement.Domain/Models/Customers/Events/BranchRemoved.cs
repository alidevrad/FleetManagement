using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Customers.Events;

public class BranchRemoved : DomainEvent
{
    public long CustomerId { get; }
    public long BranchId { get; }
    public DateTime BranchRemovedAt { get; }

    public BranchRemoved(Guid businessId, long customerId, long branchId)
        : base(aggregateType: "Customer", businessId: businessId)
    {
        CustomerId = customerId;
        BranchId = branchId;
        BranchRemovedAt = DateTime.UtcNow;
    }
}
