using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Customers.Events;

public class BranchActivated : DomainEvent
{
    public long CustomerId { get; }
    public long BranchId { get; }
    public DateTime BranchActivatedAt { get; }

    public BranchActivated(Guid businessId, long customerId, long branchId)
        : base(aggregateType: "Customer", businessId: businessId)
    {
        CustomerId = customerId;
        BranchId = branchId;
        BranchActivatedAt = DateTime.UtcNow;
    }
}
