using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class AddTrainingQualificationCommandHandler : IRequestHandler<AddTrainingQualificationCommand>
{
    private readonly IDriverCommandRepository _driverRepository;
    private readonly IDriverQueryRepository _driverQueryRepository;

    public AddTrainingQualificationCommandHandler(
        IDriverCommandRepository driverRepository,
        IDriverQueryRepository driverQueryRepository)
    {
        _driverRepository = driverRepository;
        _driverQueryRepository = driverQueryRepository;
    }

    public async Task Handle(AddTrainingQualificationCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverQueryRepository.GetByIdAsync(request.DriverId);
        if (driver == null) throw new KeyNotFoundException("Driver not found.");

        driver.AddTrainingQualification(request.QualificationName, request.ObtainedDate, request.ExpirationDate);

        _driverRepository.Update(driver);
        await _driverRepository.SaveChangesAsync();
    }
}
