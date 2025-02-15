namespace FleetManagement.Domain.Models.Trips;

// Represents an ordered destination (customer branch) for the Trip.
public class TripDestination
{
    public int Order { get; private set; }
    public long BranchId { get; private set; } // ID of the customer branch
    public double ExpectedDelayTime { get; private set; } // Expected unloading delay in minutes

    protected TripDestination() { }

    public TripDestination(int order, long branchId, double expectedDelayTime)
    {
        Order = order;
        BranchId = branchId;
        ExpectedDelayTime = expectedDelayTime;
    }
}
