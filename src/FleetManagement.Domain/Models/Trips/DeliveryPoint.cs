namespace FleetManagement.Domain.Models.Trips;

public class DeliveryPoint
{
    public long BranchId { get; private set; }
    public int Order { get; private set; }
    public string Address { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    public DeliveryPoint(long branchId,
                         int order,
                         string address,
                         double latitude,
                         double longitude)
    {
        BranchId = branchId;
        Order = order;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }
}
