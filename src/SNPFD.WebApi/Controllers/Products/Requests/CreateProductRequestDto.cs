using System.ComponentModel.DataAnnotations;
using SNPFD.Application.Products.Dtos;

namespace SNPFD.WebApi.Controllers.Products.Requests;

/// <summary>
/// 
/// </summary>
public sealed record CreateProductRequestDto
{
    
    /// <summary>
    /// max-length is 40 characters
    /// </summary>
    [MaxLength(40)] public required string Title { get; init; }
    /// <summary>
    /// it must be greater than zero
    /// </summary>
    [Range(1, int.MaxValue)] public ulong Price { get; init; }
    
    /// <summary>
    /// it's percentage of discount and must be between 1 and 100
    /// </summary>
    [Range(1, 100)] public double Discount { get; init; }
    /// <summary>
    /// inventory counts of product and must be greater than zero
    /// </summary>
    [Range(1, int.MaxValue)] public uint InventoryCount { get; init; } = 10;
    
    internal CreateProductInputDto ToInputDto()
    {
        return new CreateProductInputDto(Title,
            Price,
            Discount,
            InventoryCount);
    }
}