namespace SNPFD.WebApi.Controllers.Purchases.Requests;

public record BuyRequestDto()
{
    public Guid UserId { get; init; }
    public Guid ProductId { get; init; }
};