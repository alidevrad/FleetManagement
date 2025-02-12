using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Customers.Events;

public class BranchAdded : DomainEvent
{
    public long CustomerId { get; }
    public long BranchId { get; }
    public string Name { get; }
    public DateTime BranchAddedAt { get; }

    public BranchAdded(Guid businessId, long customerId, long branchId, string name)
        : base(aggregateType: "Customer", businessId: businessId)
    {
        CustomerId = customerId;
        BranchId = branchId;
        Name = name;
        BranchAddedAt = DateTime.UtcNow;
    }
}
