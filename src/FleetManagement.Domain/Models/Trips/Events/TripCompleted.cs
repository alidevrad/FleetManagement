using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripCompleted : DomainEvent
{
    public long TripId { get; }
    public DateTime CompletedAt { get; }

    public TripCompleted(Guid businessId, long tripId)
        : base(aggregateType: "Trip", businessId: businessId)
    {
        TripId = tripId;
        CompletedAt = DateTime.UtcNow;
    }
}
