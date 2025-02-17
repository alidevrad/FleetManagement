
namespace FleetManagement.Infrastructure.GoogleMaps;

public class GoogleMapService : IGoogleMapService
{
    public async Task<GoogleResult> CalculateShortestRouteAsync(object subTrips)
    {
        var result = new GoogleResult() { };

        return await Task.FromResult(result);
    }
}
