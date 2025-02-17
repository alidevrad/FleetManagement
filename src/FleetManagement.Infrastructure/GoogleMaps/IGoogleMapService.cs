
namespace FleetManagement.Infrastructure.GoogleMaps;

public interface IGoogleMapService
{
    Task<GoogleResult> CalculateShortestRouteAsync(object subTrips);
}

public class GoogleResult
{
    public GoogleResult()
    {
        EstimatedEndTime = DateTime.UtcNow.AddDays(10);
    }

    public DateTime EstimatedEndTime { get; set; }
}
