using System.ComponentModel.DataAnnotations;
using SNPFD.Application.Products.Dtos;

namespace SNPFD.WebApi.Controllers.Products.Requests;

public sealed record EditProductRequestDto
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

    internal EditProductInputDto ToInputDto(Guid id)
    {
        return new EditProductInputDto(id,
            Title,
            Price,
            Discount);
    }

}