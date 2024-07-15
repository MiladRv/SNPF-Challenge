using SNPFD.Domain;

namespace SNPFD.Application;

public interface IBaseRepository<TEntity, in TId>
    where TEntity : AggregateRoot<TId>
    where TId : struct
{
    Task<TEntity> AddAsync(TEntity entity,
        CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(TId id,
        CancellationToken cancellationToken = default);

    Task<TEntity> UpdateAsync(TEntity entity,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity,
        CancellationToken cancellationToken = default);
}