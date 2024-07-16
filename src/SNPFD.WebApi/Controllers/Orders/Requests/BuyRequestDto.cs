namespace SNPFD.WebApi.Controllers.Orders.Requests;

public record BuyRequestDto()
{
    /// <summary>
    /// user's id
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// product's ie
    /// </summary>
    public Guid ProductId { get; init; }
}