using FleetManagement.Application.Contract.VehicleTypes.Queries;
using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Domain.Models.VehicleTypes.Repositories;
using MediatR;

namespace FleetManagement.Application.VehicleTypes.Queries;

public class GetVehicleTypeByIdQueryHandler : IRequestHandler<GetVehicleTypeByIdQuery, VehicleType>
{
    private readonly IVehicleTypeQueryRepository _vehicleTypeQueryRepository;

    public GetVehicleTypeByIdQueryHandler(IVehicleTypeQueryRepository vehicleTypeQueryRepository)
    {
        _vehicleTypeQueryRepository = vehicleTypeQueryRepository;
    }

    public async Task<VehicleType> Handle(GetVehicleTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicleType = await _vehicleTypeQueryRepository.GetByIdAsync(request.Id);
        if (vehicleType == null)
        {
            throw new KeyNotFoundException("VehicleType not found.");
        }
        return vehicleType;
    }
}
