namespace FleetManagement.Domain.Common.BuildingBlocks.Events;

public interface IEventPublisher
{
    Task Publish<T>(T @event) where T : IDomainEvent;
}
