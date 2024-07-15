namespace SNPFD.Application.Products.Dtos;

public sealed record EditProductInputDto(
    Guid Id,
    string Title,
    ulong Price,
    double Discount);