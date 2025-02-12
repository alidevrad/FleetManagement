using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Common.BuildingBlocks.Core;

public interface IAggregateRoot
{
    void AddDomainEvent<T>(T @event) where T : IDomainEvent;

    IReadOnlyCollection<IDomainEvent> GetEvents();

    void ClearEvents();
}