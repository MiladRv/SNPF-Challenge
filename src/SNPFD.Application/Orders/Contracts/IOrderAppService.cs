using SNPFD.Application.Orders.Dtos;

namespace SNPFD.Application.Orders.Contracts;

public interface IOrderAppService
{
    Task<OrderDto> CreateAsync(Guid userId,
        Guid productId,
        CancellationToken cancellationToken = default);
    
    IEnumerable<PurchaseDto> FindByUserId(Guid userId,
        uint pageIndex = 0,
        ushort pageSize = 50);
    
}