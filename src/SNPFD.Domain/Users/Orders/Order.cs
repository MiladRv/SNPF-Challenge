using SNPFD.Domain.Products;

namespace SNPFD.Domain.Users.Orders;

public sealed class Order : EntityBase<Guid>
{
    //note: ef core needs parameterless constructor
    public Order()
    {
        
    }
    
    public Order(Guid productId,
        Guid userId)
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        ProductId = productId;
        UserId = userId;
    }

    public DateTime CreationDate { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; set; }

    public Guid ProductId { get; private set; }
    public Product Product { get; set; }
}