using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripCanceled : DomainEvent
{
    public long TripId { get; }
    public DateTime CanceledAt { get; }

    public TripCanceled(Guid businessId, long tripId)
        : base(aggregateType: "Trip", businessId: businessId)
    {
        TripId = tripId;
        CanceledAt = DateTime.UtcNow;
    }
}
