using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Customers.Events;

public class BranchDeactivated : DomainEvent
{
    public long CustomerId { get; }
    public long BranchId { get; }
    public DateTime BranchDeactivatedAt { get; }

    public BranchDeactivated(Guid businessId, long customerId, long branchId)
        : base(aggregateType: "Customer", businessId: businessId)
    {
        CustomerId = customerId;
        BranchId = branchId;
        BranchDeactivatedAt = DateTime.UtcNow;
    }
}
