using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, long>
{
    private readonly IDriverCommandRepository _driverRepository;

    public CreateDriverCommandHandler(IDriverCommandRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<long> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var businessId = Guid.NewGuid();

        var driver = new Driver(
            request.FirstName,
            request.LastName,
            request.Gender,
            request.PhoneNumber,
            request.Address,
            request.DateOfBirth,
            request.LicenseType,
            request.NativeLanguage,
            request.LicenseIssueDate,
            request.LicenseExpirationDate,
            businessId
        );

        await _driverRepository.AddAsync(driver);
        await _driverRepository.SaveChangesAsync();

        return driver.Id;
    }
}


