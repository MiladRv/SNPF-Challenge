using SNPFD.Application.Users.Contracts;
using SNPFD.Application.Users.Dtos;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Users;

public sealed class UserAppService(IUserRepository repository) : IUserAppService
{
    public async Task<UserDto> CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        var user = new User(name);

        await repository.AddAsync(user, cancellationToken);

        return user.ToDto();
    }

    public async Task<UserDto> FindByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await FindAndValidate(userId,
            cancellationToken);

        return user.ToDto();
    }

    public async Task<UserDto> EditAsync(Guid userId, string name, CancellationToken cancellationToken = default)
    {
        var user = await FindAndValidate(userId,
            cancellationToken);

        user.Edit(name);

        await repository
            .UpdateAsync(user, cancellationToken);

        return user.ToDto();
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await FindAndValidate(userId, cancellationToken);

        await repository
            .DeleteAsync(user, cancellationToken);
    }

    private async Task<User> FindAndValidate(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var user = await repository
            .GetByIdAsync(userId, cancellationToken);

        if (user is null)
            throw new Exception("user not found");

        return user;
    }
}