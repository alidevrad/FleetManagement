using FleetManagement.Application.Contract.Resources.Commands;
using FleetManagement.Domain.Models.Resources.Repositories;
using MediatR;

namespace FleetManagement.Application.Resources.Commands;


public class RollbackResourceReservationHandler : IRequestHandler<RollbackResourceReservationCommand>
{
    private readonly IResourceQueryRepository _queryRepository;
    private readonly IResourceCommandRepository _commandRepository;

    public RollbackResourceReservationHandler(IResourceQueryRepository queryRepository,
                                              IResourceCommandRepository commandRepository)
    {
        this._queryRepository = queryRepository;
        this._commandRepository = commandRepository;
    }

    public async Task Handle(RollbackResourceReservationCommand command, CancellationToken cancellationToken)
    {
        var resource = await _queryRepository.GetByResourceIdAndBusinessIdAsync(command.ResourceId, command.BusinessId);

        if (resource == null)
            throw new InvalidOperationException("Resource not found.");

        resource.Release();

        _commandRepository.Update(resource);
        await _commandRepository.SaveChangesAsync();
    }
}
