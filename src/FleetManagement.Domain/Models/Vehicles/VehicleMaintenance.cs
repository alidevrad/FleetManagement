using FleetManagement.Domain.Common.BuildingBlocks.Core;

namespace FleetManagement.Domain.Models.Vehicles;

public class VehicleMaintenance : AuditableEntity<long>
{
    public long VehicleId { get; private set; }
    public string Reason { get; private set; }
    public DateTime RepairDate { get; private set; }

    protected VehicleMaintenance() { }

    public VehicleMaintenance(long vehicleId, string reason, DateTime repairDate)
    {
        VehicleId = vehicleId;
        Reason = reason;
        RepairDate = repairDate;
    }

    public void Update(string reason)
    {
        Reason = reason;
    }
}
