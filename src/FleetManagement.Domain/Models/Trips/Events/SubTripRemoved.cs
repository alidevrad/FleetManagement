using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class SubTripRemoved : DomainEvent
{
    public long TripId { get; }
    public long SubTripId { get; }
    public DateTime RemovedAt { get; }

    public SubTripRemoved(Guid businessId, long tripId, long subTripId)
        : base(aggregateType: "Trip", businessId: businessId)
    {
        TripId = tripId;
        SubTripId = subTripId;
        RemovedAt = DateTime.UtcNow;
    }
}