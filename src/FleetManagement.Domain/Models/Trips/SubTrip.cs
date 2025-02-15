using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Trips.Enums;

namespace FleetManagement.Domain.Models.Trips;

public class SubTrip : AuditableEntity<long>
{
    public long TripId { get; private set; }
    public string Origin { get; private set; }                // For example, a pickup address
    public string Destination { get; private set; }           // For example, branch address
    public string RouteDetails { get; private set; }          // JSON or text details from Google Maps API
    public TimeSpan EstimatedDuration { get; private set; }   // Estimated travel time
    public DateTime? EndTime { get; private set; }              // Actual completion time
    public SubTripStatus Status { get; private set; }           // Pending, InProgress, Completed, Canceled
    public double FuelConsumption { get; private set; }         // Fuel consumed during this leg
    public double DelayTimeValue { get; private set; }          // Unloading delay (in minutes)

    protected SubTrip() { }

    public SubTrip(long tripId, string origin, string destination, string routeDetails, TimeSpan estimatedDuration, double fuelConsumption, double delayTimeValue = 0)
    {
        TripId = tripId;
        Origin = origin;
        Destination = destination;
        RouteDetails = routeDetails;
        EstimatedDuration = estimatedDuration;
        FuelConsumption = fuelConsumption;
        DelayTimeValue = delayTimeValue;
        Status = SubTripStatus.Pending;
    }

    public void MarkInProgress()
    {
        if (Status != SubTripStatus.Pending)
            throw new InvalidOperationException("SubTrip must be in pending status to start.");
        Status = SubTripStatus.InProgress;
    }

    public void MarkCompleted()
    {
        if (Status != SubTripStatus.InProgress)
            throw new InvalidOperationException("SubTrip must be in progress to complete.");
        Status = SubTripStatus.Completed;
        EndTime = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status == SubTripStatus.Completed)
            throw new InvalidOperationException("Completed sub-trips cannot be canceled.");
        Status = SubTripStatus.Canceled;
    }

    public void AddDelay(double delayValue)
    {
        DelayTimeValue = delayValue;
    }
}
