using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Vehicles.Events;

public class VehicleReserved : DomainEvent
{
    public long VehicleId { get; }
    public string LicensePlateNumber { get; }
    public DateTime ReservedAt { get; }

    public VehicleReserved(Guid businessId, long vehicleId, string licensePlateNumber)
        : base(aggregateType: "Vehicle", businessId: businessId)
    {
        VehicleId = vehicleId;
        LicensePlateNumber = licensePlateNumber;
        ReservedAt = DateTime.UtcNow;
    }
}
