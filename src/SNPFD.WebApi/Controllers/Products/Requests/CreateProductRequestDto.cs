using System.ComponentModel.DataAnnotations;
using SNPFD.Application.Products.Dtos;

namespace SNPFD.WebApi.Controllers.Products.Requests;

public sealed record CreateProductRequestDto
{
    
    [MaxLength(40)] public required string Title { get; init; }
    [Range(1, int.MaxValue)] public ulong Price { get; init; }
    [Range(1, 100)] public double Discount { get; init; }
    [Range(1, int.MaxValue)] public uint InventoryCount { get; init; } = 10;
    
    internal CreateProductInputDto ToInputDto()
    {
        return new CreateProductInputDto(Title,
            Price,
            Discount,
            InventoryCount);
    }
}