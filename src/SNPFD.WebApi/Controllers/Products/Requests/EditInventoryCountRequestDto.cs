using System.ComponentModel.DataAnnotations;

namespace SNPFD.WebApi.Controllers.Products.Requests;

public sealed record EditInventoryCountRequestDto
{
    [Range(1, int.MaxValue)] public uint InventoryCount { get; init; }
}