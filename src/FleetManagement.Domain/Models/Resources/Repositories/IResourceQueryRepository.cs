﻿using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Resources.Repositories;

public interface IResourceQueryRepository : IQueryRepository<long, Resource>
{
    Task<Resource> GetByResourceIdAndBusinessIdAsync(long resourceId, Guid businessId);
}
