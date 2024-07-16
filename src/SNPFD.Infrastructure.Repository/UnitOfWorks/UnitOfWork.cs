using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SNPFD.Application;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.UnitOfWorks;

public sealed class UnitOfWork(
    SNPFDDbContext context,
    IMemoryCache cache,
    ILogger<UnitOfWork> logger) : IUnitOfWork, IDisposable
{
    public void Dispose()
    {
        context.Dispose();
    }

    public async Task CommitAsync()
    {
        try
        {
            await context.SaveChangesAsync();
            
            foreach (var entityEntry in context.ChangeTracker.Entries())
            {
                var key = entityEntry.Property("Id").CurrentValue!;
                
                cache.Set(key, entityEntry.Entity);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            
            await context.Database.RollbackTransactionAsync();

            throw;
        }
    }
}