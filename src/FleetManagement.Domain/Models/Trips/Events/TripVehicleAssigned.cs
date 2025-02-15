using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Trips.Events;

public class TripVehicleAssigned(Guid BusinessId, long TripId, long VehicleId) : DomainEvent(aggregateType: "Trip", businessId: BusinessId)
{
    public DateTime AssignedAt { get; } = DateTime.UtcNow;
    public long TripId { get; } = TripId;
    public long VehicleId { get; } = VehicleId;
};
