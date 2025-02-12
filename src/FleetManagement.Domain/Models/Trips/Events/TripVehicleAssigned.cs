using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripVehicleAssigned : DomainEvent
{
    public long TripId { get; }
    public long VehicleId { get; }
    public DateTime AssignedAt { get; }

    public TripVehicleAssigned(Guid businessId, long tripId, long vehicleId)
        : base(aggregateType: "Trip", businessId: businessId)
    {
        TripId = tripId;
        VehicleId = vehicleId;
        AssignedAt = DateTime.UtcNow;
    }
}