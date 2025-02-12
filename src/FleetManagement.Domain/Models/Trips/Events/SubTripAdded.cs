using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class SubTripAdded : DomainEvent
{
    public long TripId { get; }
    public long SubTripId { get; }
    public DateTime AddedAt { get; }

    public SubTripAdded(Guid businessId, long tripId, long subTripId)
        : base(aggregateType: "Trip", businessId: businessId)
    {
        TripId = tripId;
        SubTripId = subTripId;
        AddedAt = DateTime.UtcNow;
    }
}