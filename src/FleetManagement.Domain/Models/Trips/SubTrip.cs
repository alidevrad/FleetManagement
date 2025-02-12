using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Trips.Enums;

namespace FleetManagement.Domain.Models.Trips;

public class SubTrip : AuditableEntity<long>
{
    #region Properties

    public long TripId { get; private set; }
    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public string RouteDetails { get; private set; }

    //TODO: بررسی کن که تایم اسپن خوبه یا دابل ؟ که بتونی راحت تر جمع کنی
    public TimeSpan EstimatedDuration { get; private set; }

    public DateTime? EndTime { get; private set; }
    public SubTripStatus Status { get; private set; }
    public double FuelConsumption { get; private set; }
    public double DelayTimeValue { get; private set; }

    //TODO: SubTrip should have twi side - request and response
    //Check implementation for this structure ☝
    #endregion

    #region Constructors

    protected SubTrip() { }

    public SubTrip(long tripId,
                   string origin,
                   string destination,
                   string routeDetails,
                   TimeSpan estimatedDuration,
                   double fuelConsumption,
                   double delayTimeValue = 0)
    {
        TripId = tripId;
        Origin = origin;
        Destination = destination;
        RouteDetails = routeDetails;
        EstimatedDuration = estimatedDuration;
        FuelConsumption = fuelConsumption;
        Status = SubTripStatus.Pending;
        DelayTimeValue = delayTimeValue;
    }

    #endregion

    #region Methods

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

    #endregion
}
