using SNPFD.Application.Users.Orders.Dtos;

namespace SNPFD.Application.Users.Orders.Contracts;

public interface IOrderAppService
{
    Task<OrderDto> CreateAsync(Guid productId,
        Guid userId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<OrderDto>> FindByUserId(Guid userId,
        ushort pageIndex = 0,
        ushort pageSize = 50);
}