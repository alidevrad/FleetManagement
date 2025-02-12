using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripDriverAssigned : DomainEvent
{
    public long TripId { get; }
    public long DriverId { get; }
    public DateTime AssignedAt { get; }

    public TripDriverAssigned(Guid businessId, long tripId, long driverId)
        : base(aggregateType: "Trip", businessId: businessId)
    {
        TripId = tripId;
        DriverId = driverId;
        AssignedAt = DateTime.UtcNow;
    }
}
