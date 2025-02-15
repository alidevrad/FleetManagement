using FleetManagement.Domain.Common.BuildingBlocks.Core;

namespace FleetManagement.Domain.Models.Shared;

public enum ReservationStatus : byte
{
    Active,
    Cancelled,
    Finished
}

public class ReservationPeriod : AuditableEntity<long>
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public ReservationStatus Status { get; private set; }

    public DateTime? ActivatedAt { get; private set; }
    public DateTime? CanceledAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }

    protected ReservationPeriod() { }

    public ReservationPeriod(DateTime start, DateTime end)
    {
        if (start < DateTime.UtcNow)
            throw new ArgumentException("Start time cannot be in the past.");
        if (end <= start)
            throw new ArgumentException("End time must be after start time.");

        Start = start;
        End = end;
        Status = ReservationStatus.Active;
        ActivatedAt = DateTime.UtcNow;
    }

    public bool Overlaps(DateTime start, DateTime end)
    {
        return Status == ReservationStatus.Active && Start < end && End > start;
    }

    public void Cancel()
    {
        if (Status != ReservationStatus.Active)
            throw new InvalidOperationException("Only active reservations can be cancelled.");

        Status = ReservationStatus.Cancelled;
        CanceledAt = DateTime.UtcNow;
    }

    public void Finish()
    {
        if (Status != ReservationStatus.Active)
            throw new InvalidOperationException("Only active reservations can be finished.");

        Status = ReservationStatus.Finished;
        FinishedAt = DateTime.UtcNow;
    }
}
