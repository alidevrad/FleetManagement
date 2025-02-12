using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand>
{
    private readonly IDriverCommandRepository _driverRepository;
    private readonly IDriverQueryRepository _driverQueryRepository;

    public DeleteDriverCommandHandler(
        IDriverCommandRepository driverRepository,
        IDriverQueryRepository driverQueryRepository)
    {
        _driverRepository = driverRepository;
        _driverQueryRepository = driverQueryRepository;
    }

    public async Task Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverQueryRepository.GetByIdAsync(request.Id);
        if (driver == null)
            throw new KeyNotFoundException("Driver not found.");

        _driverRepository.Delete(driver);
        await _driverRepository.SaveChangesAsync();
    }
}
