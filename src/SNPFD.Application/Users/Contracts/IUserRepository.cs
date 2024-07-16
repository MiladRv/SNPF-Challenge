using SNPFD.Application.Users.Dtos;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Users.Contracts;

public interface IUserRepository : IBaseRepository<User, Guid>
{
    IEnumerable<UserDto> GetAll(uint pageIndex, ushort pageSize);
}