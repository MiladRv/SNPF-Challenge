namespace SNPFD.Application;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}