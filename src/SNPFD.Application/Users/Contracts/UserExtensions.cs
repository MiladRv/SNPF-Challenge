using SNPFD.Application.Users.Dtos;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Users.Contracts;

internal static class UserExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto(user.Id,
            user.Name);
    }
}