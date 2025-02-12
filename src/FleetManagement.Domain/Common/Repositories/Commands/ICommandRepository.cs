using FleetManagement.Domain.Common.BuildingBlocks.Core;

namespace FleetManagement.Domain.Common.Repositories.Commands;

public interface ICommandRepository<TKey, TEntity>
 where TEntity : AuditableAggregateRoot<TKey>
 where TKey : IEquatable<TKey>
{
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task SaveChangesAsync();
}
