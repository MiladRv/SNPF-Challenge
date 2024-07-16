using SNPFD.Application.Orders.Dtos;
using SNPFD.Domain.Orders;

namespace SNPFD.Application.Orders.Contracts;

public interface IOrderRepository : IBaseRepository<Order,Guid>
{
    IEnumerable<PurchaseDto> GetByUserId(Guid userId, uint pageIndex, ushort pageSize);
}