using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripDriverAssigned(Guid BusinessId, long TripId, long DriverId)
    : DomainEvent(aggregateType: "Trip", businessId: BusinessId)
{
    public DateTime AssignedAt { get; } = DateTime.UtcNow;
    public long TripId { get; } = TripId;
    public long DriverId { get; } = DriverId;
};
