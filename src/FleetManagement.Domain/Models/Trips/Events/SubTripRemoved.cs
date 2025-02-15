using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class SubTripRemoved(Guid BusinessId, long TripId, long SubTripId) : DomainEvent(aggregateType: "Trip", businessId: BusinessId)
{
    public DateTime RemovedAt { get; } = DateTime.UtcNow;
    public long TripId { get; } = TripId;
    public long SubTripId { get; } = SubTripId;
};
