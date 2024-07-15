using SNPFD.Application.Users.Orders.Dtos;
using SNPFD.Domain.Users.Orders;

namespace SNPFD.Application.Users.Orders.Contracts;

internal static class OrderExtensions
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto(order.Id,
            order.UserId,
            order.ProductId,
            order.CreationDate);
    }
}