using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class AddEmergencyContactCommandHandler : IRequestHandler<AddEmergencyContactCommand>
{
    private readonly IDriverCommandRepository _driverRepository;
    private readonly IDriverQueryRepository _driverQueryRepository;

    public AddEmergencyContactCommandHandler(
        IDriverCommandRepository driverRepository,
        IDriverQueryRepository driverQueryRepository)
    {
        _driverRepository = driverRepository;
        _driverQueryRepository = driverQueryRepository;
    }

    public async Task Handle(AddEmergencyContactCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverQueryRepository.GetByIdAsync(request.DriverId);
        if (driver == null) throw new KeyNotFoundException("Driver not found.");

        driver.AddEmergencyContact(request.Name, request.Relationship, request.PhoneNumber);

        _driverRepository.Update(driver);
        await _driverRepository.SaveChangesAsync();
    }
}
