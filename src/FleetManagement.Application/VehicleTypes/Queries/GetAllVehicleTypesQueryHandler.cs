using FleetManagement.Application.Contract.VehicleTypes.Queries;
using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Domain.Models.VehicleTypes.Repositories;
using MediatR;

namespace FleetManagement.Application.VehicleTypes.Queries;

public class GetAllVehicleTypesQueryHandler : IRequestHandler<GetAllVehicleTypesQuery, List<VehicleType>>
{
    private readonly IVehicleTypeQueryRepository _vehicleTypeQueryRepository;

    public GetAllVehicleTypesQueryHandler(IVehicleTypeQueryRepository vehicleTypeQueryRepository)
    {
        _vehicleTypeQueryRepository = vehicleTypeQueryRepository;
    }

    public async Task<List<VehicleType>> Handle(GetAllVehicleTypesQuery request, CancellationToken cancellationToken)
    {
        return await _vehicleTypeQueryRepository.GetAllAsync();
    }
}
