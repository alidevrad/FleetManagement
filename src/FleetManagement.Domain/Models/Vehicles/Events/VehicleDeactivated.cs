using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Vehicles.Events;

public class VehicleDeactivated : DomainEvent
{
    public long VehicleId { get; }
    public DateTime DeactivationTime { get; }

    public VehicleDeactivated(Guid businessId, long vehicleId)
        : base("Vehicle", businessId)
    {
        VehicleId = vehicleId;
        DeactivationTime = DateTime.UtcNow;
    }
}