using FleetManagement.Application.Contract.Drivers.Queries;
using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Queries;

public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, Driver>
{
    private readonly IDriverQueryRepository _driverQueryRepository;

    public GetDriverByIdQueryHandler(IDriverQueryRepository driverQueryRepository)
    {
        _driverQueryRepository = driverQueryRepository;
    }

    public async Task<Driver> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
    {
        var driver = await _driverQueryRepository.GetByIdAsync(request.Id);

        if (driver == null)
            throw new KeyNotFoundException("Driver not found.");

        return driver;
    }
}
