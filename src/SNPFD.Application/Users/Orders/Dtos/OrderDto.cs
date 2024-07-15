namespace SNPFD.Application.Users.Orders.Dtos;

public sealed record OrderDto(
    Guid Id,
    Guid UserId,
    Guid ProductId,
    DateTime CreationDate) : BaseDto<Guid>(Id);