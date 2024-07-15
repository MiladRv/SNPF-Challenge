using SNPFD.Application.Users.Contracts;
using SNPFD.Application.Users.Orders.Contracts;
using SNPFD.Application.Users.Orders.Dtos;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Users.Orders;

public sealed class OrderAppService(IUserRepository repository) : IOrderAppService
{
    public async Task<OrderDto> CreateAsync(Guid productId,
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var user = await FindAndValidateUser(userId, cancellationToken);

        var order = user.AddOrder(productId);

        await repository
            .UpdateAsync(user, cancellationToken);

        return order.ToDto();
    }

    public async Task<IEnumerable<OrderDto>> FindByUserId(Guid userId,
        ushort pageIndex = 0,
        ushort pageSize = 50)
    {
        var user = await FindAndValidateUser(userId);

        return user
            .Orders
            .OrderByDescending(order => order.CreationDate)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .Select(order => order.ToDto());
    }

    private async Task<User> FindAndValidateUser(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var user = await repository
            .GetByIdAsync(userId, cancellationToken);

        if (user is null)
            throw new Exception("user not found");

        return user;
    }
}