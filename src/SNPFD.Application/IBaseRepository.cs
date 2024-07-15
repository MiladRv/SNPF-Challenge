using SNPFD.Domain;

namespace SNPFD.Application;

public interface IBaseRepository<TEntity, in TKey>
    where TEntity : AggregateRoot<TKey>
    where TKey : struct
{
    Task<TEntity> AddAsync(TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(TKey id,
        CancellationToken cancellationToken = default);

    Task<TEntity> UpdateAsync(TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}