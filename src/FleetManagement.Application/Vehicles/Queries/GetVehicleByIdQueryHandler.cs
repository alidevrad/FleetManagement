using FleetManagement.Application.Contract.Vehicles.Queries;
using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Queries;

public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Vehicle>
{
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public GetVehicleByIdQueryHandler(IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task<Vehicle> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleQueryRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
        {
            throw new KeyNotFoundException("Vehicle not found.");
        }
        return vehicle;
    }
}
