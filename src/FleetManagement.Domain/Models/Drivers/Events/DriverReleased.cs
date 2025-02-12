using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Drivers.Events;

public class DriverReleased : DomainEvent
{
    public long DriverId { get; }
    public DateTime ReleasedAt { get; }

    public DriverReleased(Guid businessId, long driverId)
        : base("Driver", businessId)
    {
        DriverId = driverId;
        ReleasedAt = DateTime.UtcNow;
    }
}
