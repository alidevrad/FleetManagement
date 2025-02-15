using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripCompleted(Guid BusinessId, long TripId) : DomainEvent(aggregateType: "Trip", businessId: BusinessId)
{
    public DateTime CompletedAt { get; } = DateTime.UtcNow;
    public long TripId { get; } = TripId;
};
