using FleetManagement.Application.Contract.Resources.Commands;
using FleetManagement.Domain.Models.Resources.Repositories;
using MediatR;

namespace FleetManagement.Application.Resources.Commands;

public class ReleaseResourceCommandHandler : IRequestHandler<ReleaseResourceCommand>
{
    private readonly IResourceCommandRepository _resourceRepository;

    public ReleaseResourceCommandHandler(IResourceCommandRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public async Task Handle(ReleaseResourceCommand request, CancellationToken cancellationToken)
    {
        await _resourceRepository.ReleaseResource(request.ResourceId, request.ResourceType);
    }
}