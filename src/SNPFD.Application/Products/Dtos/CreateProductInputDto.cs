namespace SNPFD.Application.Products.Requests;

public sealed record CreateProductInputDto(string Title,
    ulong Price,
    double Discount,
    uint InventoryCount = 10);