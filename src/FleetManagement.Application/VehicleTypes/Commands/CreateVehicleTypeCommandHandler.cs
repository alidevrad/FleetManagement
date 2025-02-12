using FleetManagement.Application.Contract.VehicleTypes.Commands;
using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Domain.Models.VehicleTypes.Repositories;
using MediatR;

namespace FleetManagement.Application.VehicleTypes.Commands;

public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, long>
{
    private readonly IVehicleTypeCommandRepository _vehicleTypeRepository;

    public CreateVehicleTypeCommandHandler(IVehicleTypeCommandRepository vehicleTypeRepository)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
    }

    public async Task<long> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = new VehicleType(
            name: request.Name,
            category: request.Category,
            maxWeightCapacity: request.MaxWeightCapacity,
            maxVolumeCapacity: request.MaxVolumeCapacity,
            fuelType: request.FuelType,
            averageFuelConsumption: request.AverageFuelConsumption,
            requiredLicenseType: request.RequiredLicenseType,
            isRefrigerated: request.IsRefrigerated,
            isHazardousMaterialApproved: request.IsHazardousMaterialApproved,
            maxSpeedLimit: request.MaxSpeedLimit,
            numberOfWheels: request.NumberOfWheels,
            businessId: Guid.NewGuid()
        );

        await _vehicleTypeRepository.AddAsync(vehicleType);
        await _vehicleTypeRepository.SaveChangesAsync();

        return vehicleType.Id;
    }
}
