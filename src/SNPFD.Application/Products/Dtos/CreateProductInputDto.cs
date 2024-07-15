namespace SNPFD.Application.Products.Dtos;

public sealed record CreateProductInputDto(string Title,
    ulong Price,
    double Discount,
    uint InventoryCount = 10);