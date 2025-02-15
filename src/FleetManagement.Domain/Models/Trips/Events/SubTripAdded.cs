using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class SubTripAdded(Guid BusinessId, long TripId, long SubTripId) : DomainEvent(aggregateType: "Trip", businessId: BusinessId)
{
    public DateTime AddedAt { get; } = DateTime.UtcNow;
    public long TripId { get; } = TripId;
    public long SubTripId { get; } = SubTripId;
};
