namespace SNPFD.Application.Purchases.Dtos;

public sealed record PurchaseInputDto
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}