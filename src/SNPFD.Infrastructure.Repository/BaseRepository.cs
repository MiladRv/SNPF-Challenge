using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SNPFD.Application;
using SNPFD.Domain;

namespace SNPFD.Infrastructure.Repository;

public abstract class BaseRepository<TEntity, TKey>(
    DbContext dbContext,
    IMemoryCache cache) :
    IBaseRepository<TEntity, TKey>, IDisposable
    where TEntity : AggregateRoot<TKey>
    where TKey : struct
{
    private bool _disposed;
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = new())
    {
        var entityEntry = await DbSet.AddAsync(entity, cancellationToken);

        if (!saveChanges)
            return entityEntry.Entity;

        await dbContext.SaveChangesAsync(cancellationToken);

        cache.Set(entityEntry.Entity.Id, entityEntry.Entity);

        return entityEntry.Entity;
    }

    public async Task DeleteAsync(TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = new())
    {
        DbSet.Remove(entity);

        if (!saveChanges)
            return;

        await dbContext.SaveChangesAsync(cancellationToken);
        cache.Remove(entity.Id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = new())
    {
        if (!dbContext.ChangeTracker.HasChanges())
            return entity;

        var entityEntry = DbSet.Update(entity);

        if (!saveChanges)
            return entityEntry.Entity;

        await dbContext.SaveChangesAsync(cancellationToken);
        cache.Set(entity.Id, entity);

        return entityEntry.Entity;
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        if (cache.TryGetValue(id, out var cachedObject))
        {
            return (TEntity?)cachedObject;
        }

        var entity = await DbSet
            .FirstOrDefaultAsync(t => t.Id.Equals(id), cancellationToken);

        if (entity is null)
            return null;
        
        cache.Set(id, entity);

        return entity;
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}