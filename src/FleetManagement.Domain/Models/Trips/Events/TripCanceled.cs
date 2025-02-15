using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripCanceled(Guid BusinessId, long TripId) : DomainEvent(aggregateType: "Trip", businessId: BusinessId)
{
    public DateTime CanceledAt { get; } = DateTime.UtcNow;
    public long TripId { get; } = TripId;
};
