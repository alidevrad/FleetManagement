using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Vehicles.Events;

namespace FleetManagement.Domain.Models.Vehicles;

public class Vehicle : AuditableAggregateRoot<long>
{
    #region Properties

    public long VehicleTypeId { get; private set; }
    public string Manufacturer { get; private set; }
    public string LicensePlateNumber { get; private set; }
    public int ModelYear { get; private set; }
    public string Color { get; private set; }
    public bool IsAvailable { get; private set; }

    private readonly List<VehicleMaintenance> _vehicleMaintenances = new();
    public IReadOnlyList<VehicleMaintenance> VehicleMaintenances => _vehicleMaintenances.AsReadOnly();

    #endregion

    #region Constructors

    protected Vehicle() : base(Guid.NewGuid()) { }

    public Vehicle(long vehicleTypeId,
                   string manufacturer,
                   string licensePlateNumber,
                   int modelYear,
                   string color,
                   Guid businessId
                   )
        : base(businessId)
    {
        VehicleTypeId = vehicleTypeId;
        Manufacturer = manufacturer;
        LicensePlateNumber = licensePlateNumber;
        ModelYear = modelYear;
        Color = color;
        IsAvailable = true;
    }

    #endregion

    #region Methods

    public void Reserve()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("Vehicle is already reserved or unavailable.");

        IsAvailable = false;
        AddDomainEvent(new VehicleReserved(BusinessId, Id, LicensePlateNumber));
    }

    public void Release()
    {
        if (IsAvailable)
            throw new InvalidOperationException("Vehicle is already available.");

        IsAvailable = true;
        AddDomainEvent(new VehicleReleased(BusinessId, Id, LicensePlateNumber));
    }

    public void AddMaintenanceRecord(string reason, DateTime repairDate)
    {
        _vehicleMaintenances.Add(new VehicleMaintenance(Id, reason, repairDate));
        AddDomainEvent(new VehicleMaintenanceAdded(BusinessId, Id, reason, repairDate));
    }

    public void Update(long vehicleTypeId,
                       string manufacturer,
                       string licensePlateNumber,
                       int modelYear,
                       string color)
    {
        VehicleTypeId = vehicleTypeId;
        Manufacturer = manufacturer;
        LicensePlateNumber = licensePlateNumber;
        ModelYear = modelYear;
        Color = color;
    }

    #endregion
}
