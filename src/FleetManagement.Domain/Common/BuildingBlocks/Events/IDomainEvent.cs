namespace FleetManagement.Domain.Common.BuildingBlocks.Events;

public interface IDomainEvent : IEvent
{
    public bool IsUsed { get; }
    public string AggregateType { get; }

}
