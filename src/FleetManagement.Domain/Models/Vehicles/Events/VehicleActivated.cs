using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Vehicles.Events;

public class VehicleActivated : DomainEvent
{
    public long VehicleId { get; }
    public DateTime ActivationTime { get; }

    public VehicleActivated(Guid businessId, long vehicleId)
        : base("Vehicle", businessId)
    {
        VehicleId = vehicleId;
        ActivationTime = DateTime.UtcNow;
    }
}
