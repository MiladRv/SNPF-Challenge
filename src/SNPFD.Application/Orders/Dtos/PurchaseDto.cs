namespace SNPFD.Application.Orders.Dtos;

public sealed record PurchaseDto(
    Guid UserId,
    string UserName,
    Guid ProductId,
    string ProductTitle,
    ulong Price,
    ulong DiscountedPrice,
    Guid OrderId,
    DateTime PurchaseDate);