using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SNPFD.Application.Users.Contracts;
using SNPFD.Application.Users.Dtos;
using SNPFD.Domain.Users;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.Users;

public sealed class UserRepository(SNPFDDbContext dbContext,IMemoryCache memoryCache)
    : BaseRepository<User, Guid>(dbContext,memoryCache), IUserRepository
{
    public IEnumerable<UserDto> GetAll(uint pageIndex, ushort pageSize)
    {
        return DbSet
            .AsNoTracking()
            .OrderBy(user => user.Name)
            .Skip((int)(pageSize * pageIndex))
            .Take(pageSize)
            .Select(user => UserExtensions.ToDto(ref user));
    }
}