using System.ComponentModel.DataAnnotations;

namespace SNPFD.WebApi.Controllers.Products.Requests;

/// <summary>
/// 
/// </summary>
public sealed record EditInventoryCountRequestDto
{
    /// <summary>
    /// inventory counts of product and must be greater than zero
    /// </summary>
    [Range(1, int.MaxValue)] public uint InventoryCount { get; init; }
}