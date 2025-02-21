using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Trips.Enums;

namespace FleetManagement.Domain.Models.Trips;

public class SubTrip : AuditableEntity<long>
{
    public long TripId { get; private set; }
    public string Origin { get; private set; }

    public DeliveryPoint DeliveryPoint { get; private set; }

    public string RouteDetails { get; private set; }
    public TimeSpan EstimatedDuration { get; private set; }
    public DateTime? EndTime { get; private set; }
    public SubTripStatus Status { get; private set; }
    public double FuelConsumption { get; private set; }
    public double DelayTimeValue { get; private set; }

    //TODO: setup StartDateTime
    public DateTime StartDateTime { get; private set; }

    protected SubTrip() { }

    public SubTrip(long tripId,
                   string origin,
                   DeliveryPoint deliveryPoint,
                   string routeDetails,
                   TimeSpan estimatedDuration,
                   double fuelConsumption,
                   double delayTimeValue = 0)
    {
        TripId = tripId;
        Origin = origin;
        RouteDetails = routeDetails;
        EstimatedDuration = estimatedDuration;
        FuelConsumption = fuelConsumption;
        DelayTimeValue = delayTimeValue;
        DeliveryPoint = deliveryPoint;
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
