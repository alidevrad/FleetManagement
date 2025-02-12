using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Common.Repositories.Queries;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FleetManagement.Persistence.EF.Repositories;

public class BaseQueryRepository<TKey, TEntity> : IQueryRepository<TKey, TEntity>
    where TEntity : AuditableAggregateRoot<TKey>
    where TKey : IEquatable<TKey>
{
    protected readonly FleetManagementDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseQueryRepository(FleetManagementDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
}