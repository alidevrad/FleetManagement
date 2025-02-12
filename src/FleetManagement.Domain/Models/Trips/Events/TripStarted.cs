using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripStarted : DomainEvent
{
    public long TripId { get; }
    public DateTime StartedAt { get; }

    public TripStarted(Guid businessId, long tripId)
        : base(aggregateType: "Trip", businessId: businessId)
    {
        TripId = tripId;
        StartedAt = DateTime.UtcNow;
    }
}
