using SNPFD.Domain.Users;

namespace SNPFD.Application.Users.Contracts;

public interface IUserRepository : IBaseRepository<User, Guid>
{
}