using FleetManagement.Application.Contract.Vehicles.Queries;
using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Queries;

public class GetVehicleMaintenancesQueryHandler : IRequestHandler<GetVehicleMaintenancesQuery, List<VehicleMaintenance>>
{
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public GetVehicleMaintenancesQueryHandler(IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task<List<VehicleMaintenance>> Handle(GetVehicleMaintenancesQuery request, CancellationToken cancellationToken)
    {
        return await _vehicleQueryRepository.GetVehicleMaintenancesByVehicleId(request.VehicleId);
    }
}
