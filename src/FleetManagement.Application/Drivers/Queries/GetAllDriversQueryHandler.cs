using FleetManagement.Application.Contract.Drivers.Queries;
using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Queries;

public class GetAllDriversQueryHandler : IRequestHandler<GetAllDriversQuery, List<Driver>>
{
    private readonly IDriverQueryRepository _driverQueryRepository;

    public GetAllDriversQueryHandler(IDriverQueryRepository driverQueryRepository)
    {
        _driverQueryRepository = driverQueryRepository;
    }

    public async Task<List<Driver>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        return await _driverQueryRepository.GetAllAsync();
    }
}
