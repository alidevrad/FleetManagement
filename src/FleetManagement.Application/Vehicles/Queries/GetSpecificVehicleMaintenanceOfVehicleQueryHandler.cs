using FleetManagement.Application.Contract.Vehicles.Queries;
using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Queries;

public class GetSpecificVehicleMaintenanceOfVehicleQueryHandler : IRequestHandler<GetSpecificVehicleMaintenanceOfVehicleQuery, VehicleMaintenance>
{
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public GetSpecificVehicleMaintenanceOfVehicleQueryHandler(IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task<VehicleMaintenance> Handle(GetSpecificVehicleMaintenanceOfVehicleQuery request, CancellationToken cancellationToken)
    {
        return await _vehicleQueryRepository.GetSpecificVehicleMaintenanceOfVehicle(request.VehicleId, request.VehicleMaintenanceId);
    }
}
