using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class RollbackDriverReservationHandler : IRequestHandler<RollbackDriverReservationCommand>
{
    private readonly IDriverQueryRepository _driverQueryRepository;
    private readonly IDriverCommandRepository _commandRepository;

    public RollbackDriverReservationHandler(IDriverQueryRepository driverQueryRepository, IDriverCommandRepository commandRepository)
    {
        this._driverQueryRepository = driverQueryRepository;
        this._commandRepository = commandRepository;
    }

    public async Task Handle(RollbackDriverReservationCommand command, CancellationToken cancellationToken)
    {
        var driver = await _driverQueryRepository.GetByIdAsync(command.DriverId);
        if (driver == null)
            throw new InvalidOperationException("Driver not found.");

        //TODO: Next phase
        //driver.Release(command.ReservationId);

        _commandRepository.Update(driver);
        await _commandRepository.SaveChangesAsync();
    }
}
