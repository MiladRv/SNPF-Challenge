using SNPFD.Application.Users.Dtos;

namespace SNPFD.Application.Users.Contracts;

public interface IUserAppService
{
    Task<UserDto> CreateAsync(string name,
        CancellationToken cancellationToken = default);

    Task<UserDto> FindByIdAsync(Guid userId,
        CancellationToken cancellationToken = default);

    Task<UserDto> EditAsync(Guid userId,
        string name,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid userId,
        CancellationToken cancellationToken = default);

    IEnumerable<UserDto> GetAll(uint pageIndex, ushort pageSize);
}