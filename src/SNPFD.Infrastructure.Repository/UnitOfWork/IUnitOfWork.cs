namespace SNPFD.Infrastructure.Repository.UnitOfWork;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}