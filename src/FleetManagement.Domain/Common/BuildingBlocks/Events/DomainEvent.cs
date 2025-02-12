namespace FleetManagement.Domain.Common.BuildingBlocks.Events;

public abstract class DomainEvent : IDomainEvent
{
    public Guid EventId { get; }
    public DateTime PublishDateTime { get; }
    public bool IsUsed { get; private set; }
    public string AggregateType { get; }
    public Guid BusinessId { get; }

    protected DomainEvent(string aggregateType, Guid businessId)
    {
        EventId = Guid.NewGuid();
        PublishDateTime = DateTime.UtcNow;
        IsUsed = false;
        AggregateType = aggregateType;
        BusinessId = businessId;
    }

    public void MarkAsUsed()
    {
        IsUsed = true;
    }
}