namespace SNPFD.Domain.Users.Orders;

public class Order : EntityBase<Guid>
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
    public virtual User User { get; set; }

    public Guid ProductId { get; private set; }
}