using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand>
{
    private readonly IDriverCommandRepository _driverRepository;
    private readonly IDriverQueryRepository _driverQueryRepository;

    public UpdateDriverCommandHandler(
        IDriverCommandRepository driverRepository,
        IDriverQueryRepository driverQueryRepository)
    {
        _driverRepository = driverRepository;
        _driverQueryRepository = driverQueryRepository;
    }

    public async Task Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverQueryRepository.GetByIdAsync(request.Id);

        if (driver == null)
        {
            throw new KeyNotFoundException("Driver not found.");
        }

        driver.Update(
            request.FirstName,
            request.LastName,
            request.Gender,
            request.PhoneNumber,
            request.Address,
            request.DateOfBirth,
            request.LicenseType,
            request.NativeLanguage,
            request.LicenseIssueDate,
            request.LicenseExpirationDate
        );

        _driverRepository.Update(driver);
        await _driverRepository.SaveChangesAsync();
    }
}


