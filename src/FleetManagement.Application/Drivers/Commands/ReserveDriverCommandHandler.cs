using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class ReserveDriverCommandHandler : IRequestHandler<ReserveDriverCommand>
{
    private readonly IDriverCommandRepository _driverRepository;
    private readonly IDriverQueryRepository _driverQueryRepository;

    public ReserveDriverCommandHandler(
        IDriverCommandRepository driverRepository,
        IDriverQueryRepository driverQueryRepository)
    {
        _driverRepository = driverRepository;
        _driverQueryRepository = driverQueryRepository;
    }

    public async Task Handle(ReserveDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverQueryRepository.GetByIdAsync(request.Id);
        if (driver == null)
        {
            throw new KeyNotFoundException("Driver not found.");
        }

        driver.Reserve(request.Start, request.End);

        _driverRepository.Update(driver);
        await _driverRepository.SaveChangesAsync();
    }
}

