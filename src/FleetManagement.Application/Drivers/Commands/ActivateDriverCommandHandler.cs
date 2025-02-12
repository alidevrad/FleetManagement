using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class ActivateDriverCommandHandler : IRequestHandler<ActivateDriverCommand>
{
    private readonly IDriverCommandRepository _commandRepository;
    private readonly IDriverQueryRepository _queryRepository;

    public ActivateDriverCommandHandler(IDriverCommandRepository commandRepository,
                                         IDriverQueryRepository queryRepository)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public async Task Handle(ActivateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _queryRepository.GetByIdAsync(request.Id);
        if (driver == null)
        {
            throw new KeyNotFoundException("Driver not found");
        }

        driver.Activate();

        _commandRepository.Update(driver);
        await _commandRepository.SaveChangesAsync();
    }
}
