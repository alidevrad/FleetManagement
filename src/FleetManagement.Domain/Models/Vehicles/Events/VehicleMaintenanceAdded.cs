using FleetManagement.Domain.Common.BuildingBlocks.Events;

namespace FleetManagement.Domain.Models.Vehicles.Events;

public class VehicleMaintenanceAdded : DomainEvent
{
    public long VehicleId { get; }
    public string Reason { get; }
    public DateTime RepairDate { get; }

    public VehicleMaintenanceAdded(Guid businessId, long vehicleId, string reason, DateTime repairDate)
        : base(aggregateType: "Vehicle", businessId: businessId)
    {
        VehicleId = vehicleId;
        Reason = reason;
        RepairDate = repairDate;
    }
}
