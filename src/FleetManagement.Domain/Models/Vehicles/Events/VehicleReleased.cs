using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Vehicles.Events;

public class VehicleReleased : DomainEvent
{
    public long VehicleId { get; }
    public string LicensePlateNumber { get; }
    public DateTime ReleasedAt { get; }

    public VehicleReleased(Guid businessId, long vehicleId, string licensePlateNumber)
        : base(aggregateType: "Vehicle", businessId: businessId)
    {
        VehicleId = vehicleId;
        LicensePlateNumber = licensePlateNumber;
        ReleasedAt = DateTime.UtcNow;
    }
}