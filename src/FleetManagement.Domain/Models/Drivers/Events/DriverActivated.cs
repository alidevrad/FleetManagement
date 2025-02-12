using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Drivers.Events;

public class DriverActivated : DomainEvent
{
    public long DriverId { get; }
    public DateTime ActivationTime { get; }

    public DriverActivated(Guid businessId, long driverId)
        : base("Driver", businessId)
    {
        DriverId = driverId;
        ActivationTime = DateTime.UtcNow;
    }
}
