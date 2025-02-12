using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Common.Repositories.Commands;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Persistence.EF.Repositories;
public class BaseCommandRepository<TKey, TEntity> : ICommandRepository<TKey, TEntity>
    where TEntity : AuditableAggregateRoot<TKey>
    where TKey : IEquatable<TKey>
{
    protected readonly FleetManagementDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseCommandRepository(FleetManagementDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        entity.MarkAsDeleted();
        _dbSet.Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
