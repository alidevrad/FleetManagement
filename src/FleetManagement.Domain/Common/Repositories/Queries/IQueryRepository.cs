using FleetManagement.Domain.Common.BuildingBlocks.Core;
using System.Linq.Expressions;

namespace FleetManagement.Domain.Common.Repositories.Queries;

public interface IQueryRepository<TKey, TEntity>
where TEntity : AuditableAggregateRoot<TKey>
where TKey : IEquatable<TKey>
{
    Task<TEntity> GetByIdAsync(TKey id);
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
}
