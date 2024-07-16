namespace SNPFD.Application;

public interface IUnitOfWork
{
    Task CommitAsync();
}