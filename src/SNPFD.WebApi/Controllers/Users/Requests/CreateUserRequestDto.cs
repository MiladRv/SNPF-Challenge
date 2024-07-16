using System.ComponentModel.DataAnnotations;

namespace SNPFD.WebApi.Controllers.Users.Requests;

/// <summary>
/// CreateUserRequestDto
/// </summary>
public sealed record CreateUserRequestDto()
{
    /// <summary>
    /// max-length is 40 characters
    /// </summary>
    [MinLength(1)] public required string Name { get; init; }
}