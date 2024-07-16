using SNPFD.Application.Users.Dtos;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Users.Contracts;

public static class UserExtensions
{
    public static UserDto ToDto(ref User user)
    {
        return new UserDto(user.Id,
            user.Name);
    }
}