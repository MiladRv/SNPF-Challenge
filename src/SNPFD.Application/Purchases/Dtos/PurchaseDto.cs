namespace SNPFD.Application.Purchases.Dtos;

public sealed record PurchaseDto(
    Guid UserId,
    string UserName,
    Guid ProductId,
    string ProductTitle,
    ulong Price,
    Guid OrderId,
    DateTime PurchaseDate);