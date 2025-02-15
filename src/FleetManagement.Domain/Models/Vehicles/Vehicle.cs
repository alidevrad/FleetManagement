using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Shared;
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

    private readonly List<VehicleMaintenance> _vehicleMaintenances = new();
    public IReadOnlyList<VehicleMaintenance> VehicleMaintenances => _vehicleMaintenances.AsReadOnly();

    private readonly List<ReservationPeriod> _reservationPeriods = new();
    public IReadOnlyList<ReservationPeriod> ReservationPeriods => _reservationPeriods.AsReadOnly();

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
    }

    #endregion

    #region Methods

    public bool IsAvailableForPeriod(DateTime start, DateTime end)
    {
        return !_reservationPeriods.Any(r => r.Status == ReservationStatus.Active && r.Overlaps(start, end));
    }

    public bool IsCurrentlyAvailable()
    {
        var now = DateTime.UtcNow;
        return !_reservationPeriods.Any(r => r.Status == ReservationStatus.Active && now >= r.Start && now < r.End);
    }

    public void Reserve(DateTime start, DateTime end)
    {
        if (!IsAvailableForPeriod(start, end))
            throw new InvalidOperationException("The selected time period overlaps with an existing reservation.");

        var reservation = new ReservationPeriod(start, end);
        _reservationPeriods.Add(reservation);
    }

    public void Release(long reservationId)
    {
        var reservation = _reservationPeriods.FirstOrDefault(r => r.Id == reservationId);
        if (reservation == null)
            throw new InvalidOperationException("Reservation not found.");

        if (reservation.Status == ReservationStatus.Cancelled)
            throw new InvalidOperationException("Reservation is already cancelled.");

        reservation.Cancel();
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
