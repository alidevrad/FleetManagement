using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Common.BuildingBlocks.Core;

public abstract class AuditableAggregateRoot<TKey> :
    AuditableEntity<TKey>, IAggregateRoot
    where TKey : IEquatable<TKey>
{
    private readonly List<IDomainEvent> _domainEvents;

    public Guid BusinessId { get; }

    protected AuditableAggregateRoot(Guid businessId)
        : base()
    {
        BusinessId = businessId;
        _domainEvents = new List<IDomainEvent>();
    }

    public void AddDomainEvent<T>(T @event) where T : IDomainEvent
    {
        _domainEvents.Add(@event);
    }

    public IReadOnlyCollection<IDomainEvent> GetEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }
}
