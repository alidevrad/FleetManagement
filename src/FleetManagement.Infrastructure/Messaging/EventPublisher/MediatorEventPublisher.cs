using FleetManagement.Domain.Common.BuildingBlocks.Events;
using FleetManagement.Infrastructure.Messaging.NotificationEvents;
using MediatR;

namespace FleetManagement.Infrastructure.Messaging.EventPublisher;

public class MediatorEventPublisher : IEventPublisher
{
    private readonly IMediator _mediator;

    public MediatorEventPublisher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Publish<T>(T @event) where T : IDomainEvent
    {
        var notification = new DomainEventNotification<T>(@event);
        await _mediator.Publish(notification);
    }
}
