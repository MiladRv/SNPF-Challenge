using SNPFD.Domain.Orders;

namespace SNPFD.Application.Orders.Contracts;

public interface IOrderRepository : IBaseRepository<Order,Guid>
{
    IEnumerable<Order> GetByUserId(Guid userId, uint pageIndex, ushort pageSize);
}