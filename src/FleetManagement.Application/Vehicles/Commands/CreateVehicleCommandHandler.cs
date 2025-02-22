using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using FleetManagement.Domain.Models.VehicleTypes.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, long>
{
    private readonly IVehicleCommandRepository _vehicleRepository;
    private readonly IVehicleTypeQueryRepository _vehicleTypeRepository;

    public CreateVehicleCommandHandler(
        IVehicleCommandRepository vehicleRepository,
        IVehicleTypeQueryRepository vehicleTypeRepository)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleTypeRepository = vehicleTypeRepository;
    }

    public async Task<long> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = await _vehicleTypeRepository.GetByIdAsync(request.VehicleTypeId);
        if (vehicleType is null)
        {
            throw new InvalidOperationException("Invalid VehicleTypeId.");
        }

        var businessId = Guid.NewGuid();

        var vehicle = new Vehicle(
            request.VehicleTypeId,
            request.Manufacturer,
            request.LicensePlateNumber,
            request.ModelYear,
            request.Color,
            businessId,
            request.LicensePlateImageUrl
        );

        await _vehicleRepository.AddAsync(vehicle);
        await _vehicleRepository.SaveChangesAsync();

        return vehicle.Id;
    }
}
