using SNPFD.Application.Orders.Dtos;
using SNPFD.Domain.Orders;

namespace SNPFD.Application.Orders.Contracts;

internal static class OrderExtensions
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto(order.Id,
            order.UserId,
            order.ProductId,
            order.CreationDate);
    }

    public static PurchaseDto ToPurchaseDto(this Order order)
    {
        return new PurchaseDto(order.Id,
            order.User.Name,
            order.ProductId,
            order.Product.Title,
            order.Product.Price,
            order.Product.DiscountedPrice,
            order.Id,
            order.CreationDate);
    }
}