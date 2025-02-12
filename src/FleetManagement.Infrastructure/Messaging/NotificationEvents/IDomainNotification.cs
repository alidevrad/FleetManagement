using FleetManagement.Domain.Common.BuildingBlocks.Events;
using MediatR;

namespace FleetManagement.Infrastructure.Messaging.NotificationEvents;

public class DomainEventNotification<T> : INotification
    where T : IDomainEvent
{
    public T DomainEvent { get; }

    public DomainEventNotification(T domainEvent)
    {
        DomainEvent = domainEvent ?? throw new ArgumentNullException(nameof(domainEvent));
    }
}
