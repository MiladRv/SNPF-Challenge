namespace SNPFD.Application.Products.Dtos;

public sealed record ProductDto(
    Guid Id,
    string Title,
    uint InventoryCount,
    ulong Price,
    ulong DiscountedPrice,
    double Discount) : BaseDto<Guid>(Id);