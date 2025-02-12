using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Drivers.Events;

public class DriverReserved : DomainEvent
{
    public long DriverId { get; }
    public DateTime ReservedAt { get; }

    public DriverReserved(Guid businessId, long driverId)
        : base("Driver", businessId)
    {
        DriverId = driverId;
        ReservedAt = DateTime.UtcNow;
    }
}
