using SNPFD.Application.Orders.Dtos;
using SNPFD.Domain.Orders;

namespace SNPFD.Application.Orders.Contracts;

internal static class OrderExtensions
{
    public static OrderDto ToDto(ref Order order)
    {
        return new OrderDto(order.Id,
            order.UserId,
            order.ProductId,
            order.CreationDate);
    }

   
}