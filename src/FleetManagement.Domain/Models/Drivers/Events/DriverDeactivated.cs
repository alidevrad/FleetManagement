using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Drivers.Events;

public class DriverDeactivated : DomainEvent
{
    public long DriverId { get; }
    public DateTime DeactivationTime { get; }

    public DriverDeactivated(Guid businessId, long driverId)
        : base("Driver", businessId)
    {
        DriverId = driverId;
        DeactivationTime = DateTime.UtcNow;
    }
}
