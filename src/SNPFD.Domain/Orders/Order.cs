using SNPFD.Domain.Products;
using SNPFD.Domain.Users;

namespace SNPFD.Domain.Orders;

public class Order : AggregateRoot<Guid>
{
    //note: ef core needs parameterless constructor
    public Order()
    {
        
    }
    
    public Order(Guid userId, Guid productId)
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        ProductId = productId;
        UserId = userId;
    }

    public DateTime CreationDate { get; private set; }

    public Guid UserId { get; private set; }
    public virtual User User { get; init; }

    public Guid ProductId { get; private set; }
    public virtual Product Product { get; init; }
}