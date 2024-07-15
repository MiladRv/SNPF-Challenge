using Microsoft.Extensions.Logging;
using SNPFD.Application;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.UnitOfWorks;

public sealed class UnitOfWork(
    SNPFDDbContext context,
    ILogger<UnitOfWork> logger) : IUnitOfWork, IDisposable
{
    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<bool> CommitAsync()
    {
        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            throw;
        }

        return true;
    }
}