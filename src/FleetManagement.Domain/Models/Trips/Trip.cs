using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Trips.Enums;
using FleetManagement.Domain.Models.Trips.Events;

namespace FleetManagement.Domain.Models.Trips;

public class Trip : AuditableAggregateRoot<long>
{
    #region Properties

    public string TripName { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime? EstimatedEndTime { get; private set; }
    public DateTime? ActualEndTime { get; private set; }
    public TripStatus Status { get; private set; }
    public long DriverId { get; private set; }
    public long VehicleId { get; private set; }

    //TODO: Should order by Google API response 
    private readonly List<long> _destinations = new();
    public IReadOnlyList<long> Destinations => _destinations.AsReadOnly();

    //TODO: ببین آیا از دیت تایم استفاده کنی بهتر است یا خیر؟
    public double TotalDelayTime { get; private set; }
    public double TotalTripDuration { get; private set; }
    public double TotalFuelConsumption { get; private set; }

    //TODO: Implement a sequence for version
    public Guid Version { get; private set; }

    private readonly List<SubTrip> _subTrips = new();
    public IReadOnlyList<SubTrip> SubTrips => _subTrips.AsReadOnly();

    #endregion

    #region Constructors

    protected Trip() : base(Guid.NewGuid()) { }

    public Trip(string tripName,
                DateTime startDateTime,
                long driverId,
                long vehicleId,
                List<long> destinations)
        : base(Guid.NewGuid())
    {
        TripName = tripName;
        StartDateTime = startDateTime;
        DriverId = driverId;
        VehicleId = vehicleId;
        _destinations = destinations;
        //TODO: Version = Guid.NewGuid();
        Status = TripStatus.Scheduled;
    }

    #endregion

    #region Methods

    public void AssignDriver(long driverId)
    {
        if (Status != TripStatus.Scheduled)
            throw new InvalidOperationException("Driver can only be assigned before the trip starts.");

        DriverId = driverId;
        AddDomainEvent(new TripDriverAssigned(BusinessId, Id, driverId));
    }

    public void AssignVehicle(long vehicleId)
    {
        if (Status != TripStatus.Scheduled)
            throw new InvalidOperationException("Vehicle can only be assigned before the trip starts.");

        VehicleId = vehicleId;
        AddDomainEvent(new TripVehicleAssigned(BusinessId, Id, vehicleId));
    }

    public void AddSubTrip(SubTrip subTrip)
    {
        if (subTrip.TripId != Id)
            throw new InvalidOperationException("SubTrip must be associated with this Trip.");

        if (Status != TripStatus.Scheduled)
            throw new InvalidOperationException("Cannot add sub-trips after the trip starts.");

        _subTrips.Add(subTrip);
        AddDomainEvent(new SubTripAdded(BusinessId, Id, subTrip.Id));
    }

    public void RemoveSubTrip(SubTrip subTrip)
    {
        if (!_subTrips.Contains(subTrip))
            throw new InvalidOperationException("SubTrip does not belong to this Trip.");

        if (Status != TripStatus.Scheduled)
            throw new InvalidOperationException("Cannot remove sub-trips after the trip starts.");

        _subTrips.Remove(subTrip);
        AddDomainEvent(new SubTripRemoved(BusinessId, Id, subTrip.Id));
    }

    public void CalculateTotalTripDuration(double mapsApiDuration)
    {
        TotalTripDuration = mapsApiDuration + TotalDelayTime;
    }

    public void CalculateTotalFuelConsumption(double fuelConsumption)
    {
        TotalFuelConsumption = fuelConsumption;
    }

    public void StartTrip()
    {
        if (Status != TripStatus.Scheduled)
            throw new InvalidOperationException("Trip can only start from Scheduled state.");

        Status = TripStatus.InProgress;
        AddDomainEvent(new TripStarted(BusinessId, Id));
    }

    public void CompleteTrip()
    {
        if (Status != TripStatus.InProgress)
            throw new InvalidOperationException("Trip must be in progress to be completed.");

        Status = TripStatus.Completed;
        ActualEndTime = DateTime.UtcNow;
        AddDomainEvent(new TripCompleted(BusinessId, Id));
    }

    public void CancelTrip()
    {
        if (Status == TripStatus.Completed)
            throw new InvalidOperationException("Completed trips cannot be canceled.");

        Status = TripStatus.Canceled;
        AddDomainEvent(new TripCanceled(BusinessId, Id));
    }

    public void CalculateTotalDelayTime()
    {
        TotalDelayTime = _subTrips.Sum(subTrip => subTrip.DelayTimeValue);
    }

    public void CalculateTotalTripDuration()
    {
        TotalTripDuration = _subTrips.Sum(subTrip => subTrip.EstimatedDuration.TotalMinutes) + TotalDelayTime;
    }

    public void CalculateTotalFuelConsumption()
    {
        TotalFuelConsumption = _subTrips.Sum(subTrip => subTrip.FuelConsumption);
    }

    #endregion
}
