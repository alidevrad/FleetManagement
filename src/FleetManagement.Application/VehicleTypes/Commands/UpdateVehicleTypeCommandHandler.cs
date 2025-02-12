using FleetManagement.Application.Contract.VehicleTypes.Commands;
using FleetManagement.Domain.Models.VehicleTypes.Repositories;
using MediatR;

namespace FleetManagement.Application.VehicleTypes.Commands;

public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand>
{
    private readonly IVehicleTypeCommandRepository _vehicleTypeRepository;
    private readonly IVehicleTypeQueryRepository _vehicleTypeQueryRepository;

    public UpdateVehicleTypeCommandHandler(
        IVehicleTypeCommandRepository vehicleTypeRepository,
        IVehicleTypeQueryRepository vehicleTypeQueryRepository)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _vehicleTypeQueryRepository = vehicleTypeQueryRepository;
    }

    public async Task Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = await _vehicleTypeQueryRepository.GetByIdAsync(request.Id);

        if (vehicleType == null)
        {
            throw new KeyNotFoundException("Vehicle type not found.");
        }

        vehicleType.Update(
            request.Name,
            request.Category,
            request.MaxWeightCapacity,
            request.MaxVolumeCapacity,
            request.FuelType,
            request.AverageFuelConsumption,
            request.RequiredLicenseType,
            request.IsRefrigerated,
            request.IsHazardousMaterialApproved,
            request.MaxSpeedLimit,
            request.NumberOfWheels
        );

        _vehicleTypeRepository.Update(vehicleType);
        await _vehicleTypeRepository.SaveChangesAsync();
    }
}
