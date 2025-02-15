using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Domain.Models.Drivers.Repositories;
using MediatR;

namespace FleetManagement.Application.Drivers.Commands;

public class DeactivateDriverCommandHandler : IRequestHandler<DeactivateDriverCommand>
{
    private readonly IDriverCommandRepository _commandRepository;
    private readonly IDriverQueryRepository _queryRepository;

    public DeactivateDriverCommandHandler(IDriverCommandRepository commandRepository,
                                           IDriverQueryRepository queryRepository)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public async Task Handle(DeactivateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _queryRepository.GetByIdAsync(request.Id);
        if (driver == null)
        {
            //TODO: Write suitable exception instead of KeyNotFoundException
            throw new KeyNotFoundException("Driver not found");
        }

        driver.Deactivate();

        _commandRepository.Update(driver);
        await _commandRepository.SaveChangesAsync();
    }
}
