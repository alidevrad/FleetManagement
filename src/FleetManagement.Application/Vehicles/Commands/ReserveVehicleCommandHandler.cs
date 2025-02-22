using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class ReserveVehicleCommandHandler : IRequestHandler<ReserveVehicleCommand, long>
{
    private readonly IVehicleCommandRepository _vehicleRepository;
    private readonly IVehicleQueryRepository _vehicleQueryRepository;

    public ReserveVehicleCommandHandler(
        IVehicleCommandRepository vehicleRepository,
        IVehicleQueryRepository vehicleQueryRepository)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleQueryRepository = vehicleQueryRepository;
    }

    public async Task<long> Handle(ReserveVehicleCommand request, CancellationToken cancellationToken)
    {
        //TODO: Next phase
        //var vehicle = await _vehicleQueryRepository.GetByIdAsync(request.Id);
        //if (vehicle == null)
        //    throw new KeyNotFoundException("Vehicle not found.");

        //var reservationPeriod = vehicle.Reserve(request.Start, request.End);
        //_vehicleRepository.Update(vehicle);

        //await _vehicleRepository.SaveChangesAsync();

        //return reservationPeriod.Id;

        return await Task.FromResult(-1);
    }
}
