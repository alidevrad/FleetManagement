using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Trips.Enums;
using FleetManagement.Domain.Models.Trips.Events;

namespace FleetManagement.Domain.Models.Trips;

// Represents the entire trip with multiple stops.
public class Trip : AuditableAggregateRoot<long>
{
    #region Properties

    public string TripName { get; private set; }
    public DateTime StartDateTime { get; private set; }
    // Estimated end time will be determined after Google Maps route calculation.
    public DateTime? EstimatedEndTime { get; private set; }
    public DateTime? ActualEndTime { get; private set; }
    public TripStatus Status { get; private set; }
    public long DriverId { get; private set; }
    public long VehicleId { get; private set; }

    // Instead of just a list of destination IDs, we use an ordered list of TripDestination.
    private readonly List<TripDestination> _destinations = new();
    public IReadOnlyList<TripDestination> Destinations => _destinations.AsReadOnly();

    public double TotalDelayTime { get; private set; }          // Sum of unloading delays (in minutes)
    public double TotalTripDuration { get; private set; }         // Google Maps API duration + TotalDelayTime (in minutes)
    public double TotalFuelConsumption { get; private set; }      // Total fuel consumption (liters, for example)

    // A human-readable version number for the Trip (e.g., "V1", "V2", etc.)
    public string Version { get; private set; }

    private readonly List<SubTrip> _subTrips = new();
    public IReadOnlyList<SubTrip> SubTrips => _subTrips.AsReadOnly();

    #endregion

    #region Constructors

    protected Trip() : base(Guid.NewGuid()) { }

    public Trip(string tripName, DateTime startDateTime, long driverId, long vehicleId, List<TripDestination> destinations, Guid businessId)
        : base(businessId)
    {
        TripName = tripName;
        StartDateTime = startDateTime;
        DriverId = driverId;
        VehicleId = vehicleId;
        _destinations = destinations ?? new List<TripDestination>();
        // Initialize version as V1 for a new trip.
        Version = "V1";
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

    // Manage Destinations: add a TripDestination with an Order
    public void AddDestination(TripDestination destination)
    {
        if (Status != TripStatus.Scheduled)
            throw new InvalidOperationException("Cannot modify destinations after the trip has started.");

        _destinations.Add(destination);
        // Optionally, you might sort the list based on the Order value
        _destinations.Sort((x, y) => x.Order.CompareTo(y.Order));
        // Raise a domain event if needed (e.g., DestinationAdded)
    }

    public void RemoveDestination(TripDestination destination)
    {
        if (Status != TripStatus.Scheduled)
            throw new InvalidOperationException("Cannot modify destinations after the trip has started.");

        if (_destinations.Remove(destination))
        {
            // Optionally raise a domain event, e.g., DestinationRemoved.
        }
        else
        {
            throw new InvalidOperationException("Destination not found.");
        }
    }

    // Methods for SubTrip management
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

    // Methods for starting, completing, or canceling the trip
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
        // Upon completion, update the version for reporting purposes.
        UpdateVersion();
        AddDomainEvent(new TripCompleted(BusinessId, Id));
    }

    public void CancelTrip()
    {
        if (Status == TripStatus.Completed)
            throw new InvalidOperationException("Completed trips cannot be canceled.");

        Status = TripStatus.Canceled;
        UpdateVersion();
        AddDomainEvent(new TripCanceled(BusinessId, Id));
    }

    // Methods for calculating totals from SubTrip items
    public void CalculateTotalDelayTime()
    {
        TotalDelayTime = _subTrips.Sum(subTrip => subTrip.DelayTimeValue);
    }

    public void CalculateTotalTripDuration()
    {
        double totalEstimatedDuration = _subTrips.Sum(subTrip => subTrip.EstimatedDuration.TotalMinutes);
        TotalTripDuration = totalEstimatedDuration + TotalDelayTime;
    }

    public void CalculateTotalFuelConsumption()
    {
        TotalFuelConsumption = _subTrips.Sum(subTrip => subTrip.FuelConsumption);
    }

    // Method to update the version string
    private void UpdateVersion()
    {
        // For example, append an incrementing counter or a timestamp. Here we simply use a timestamp.
        Version = "V" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    }

    #endregion
}
