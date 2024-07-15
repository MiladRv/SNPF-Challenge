using SNPFD.Application.Users.Contracts;
using SNPFD.Domain.Users;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository;

public sealed class UserRepository(SNPFDDbContext dbContext)
    : BaseRepository<User, Guid>(dbContext), IUserRepository
{
}