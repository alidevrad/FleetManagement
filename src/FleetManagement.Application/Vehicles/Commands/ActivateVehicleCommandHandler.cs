using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using MediatR;

namespace FleetManagement.Application.Vehicles.Commands;

public class ActivateVehicleCommandHandler : IRequestHandler<ActivateVehicleCommand>
{
    private readonly IVehicleCommandRepository _commandRepository;
    private readonly IVehicleQueryRepository _queryRepository;

    public ActivateVehicleCommandHandler(IVehicleCommandRepository commandRepository,
                                         IVehicleQueryRepository queryRepository)
    {
        this._commandRepository = commandRepository;
        this._queryRepository = queryRepository;
    }

    public async Task Handle(ActivateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _queryRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
        {
            throw new KeyNotFoundException("Vehicle not found");
        }

        vehicle.Activate();

        _commandRepository.Update(vehicle);
        await _commandRepository.SaveChangesAsync();
    }
}
