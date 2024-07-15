namespace SNPFD.Application.Users.Dtos;

public sealed record UserDto(Guid Id, string Name) : BaseDto<Guid>(Id);