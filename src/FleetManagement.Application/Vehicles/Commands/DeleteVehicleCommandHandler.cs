using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
{
    private readonly IVehicleCommandRepository _vehicleRepository;
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public DeleteVehicleCommandHandler(
        IVehicleCommandRepository vehicleRepository,
        IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleQueryRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
            throw new KeyNotFoundException("Vehicle not found.");

        _vehicleRepository.Delete(vehicle);
        await _vehicleRepository.SaveChangesAsync();
    }
}
