using FleetManagement.Application.Contract.Resources.Commands;
using FleetManagement.Domain.Models.Resources.Repositories;
using MediatR;

namespace FleetManagement.Application.Resources.Commands;

public class LockResourceCommandHandler : IRequestHandler<LockResourceCommand, bool>
{
    private readonly IResourceCommandRepository _resourceRepository;

    public LockResourceCommandHandler(IResourceCommandRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public async Task<bool> Handle(LockResourceCommand request, CancellationToken cancellationToken)
    {
        return await _resourceRepository.LockResource(request.ResourceId,
                                                      request.ResourceType,
                                                      request.StartDateTime,
                                                      request.EndDateTime);
    }
}