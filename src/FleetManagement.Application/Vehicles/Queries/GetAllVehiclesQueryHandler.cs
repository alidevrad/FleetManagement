using FleetManagement.Application.Contract.Vehicles.Queries;
using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Queries;

public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, List<Vehicle>>
{
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public GetAllVehiclesQueryHandler(IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task<List<Vehicle>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        return await _vehicleQueryRepository.GetAllAsync();
    }
}
