using Microsoft.EntityFrameworkCore;
using SNPFD.Application.Users.Contracts;
using SNPFD.Domain.Users;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.Users;

public sealed class UserRepository(SNPFDDbContext dbContext)
    : BaseRepository<User, Guid>(dbContext), IUserRepository
{
    public IEnumerable<User> GetAll(uint pageIndex, ushort pageSize)
    {
        return DbSet
            .AsNoTracking()
            .OrderBy(user => user.Name)
            .Skip((int)(pageSize * pageIndex))
            .Take(pageSize);
    }
}