namespace SNPFD.Application.Orders.Dtos;

public sealed record OrderDto(
    Guid Id,
    Guid UserId,
    Guid ProductId,
    DateTime CreationDate) : BaseDto<Guid>(Id);