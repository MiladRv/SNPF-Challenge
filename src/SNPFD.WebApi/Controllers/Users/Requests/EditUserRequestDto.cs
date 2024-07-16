using System.ComponentModel.DataAnnotations;

namespace SNPFD.WebApi.Controllers.Users.Requests;

public sealed record EditUserRequestDto()
{
    /// <summary>
    /// max-length is 40 characters
    /// </summary>
    [MinLength(1)] public required string Name { get; init; }
}