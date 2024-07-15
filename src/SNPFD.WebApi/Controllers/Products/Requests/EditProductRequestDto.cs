using System.ComponentModel.DataAnnotations;
using SNPFD.Application.Products.Dtos;

namespace SNPFD.WebApi.Controllers.Products.Requests;

public sealed record EditProductRequestDto
{

    [MaxLength(40)] public required string Title { get; init; }
    [Range(1, int.MaxValue)] public ulong Price { get; init; }
    [Range(1, 100)] public double Discount { get; init; }

    public EditProductInputDto ToInputDto(Guid id)
    {
        return new EditProductInputDto(id,
            Title,
            Price,
            Discount);
    }

}