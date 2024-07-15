using System.ComponentModel.DataAnnotations;

namespace SNPFD.WebApi.Controllers.Users.Requests;

public sealed record CreateUserRequestDto()
{
    [MinLength(1)] public required string Name { get; init; }
};