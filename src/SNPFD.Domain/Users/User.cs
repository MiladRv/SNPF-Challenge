using SNPFD.Domain.Users.Orders;

namespace SNPFD.Domain.Users;

public class User : AggregateRoot<Guid>
{
    //note: ef core needs parameterless constructor
    public User()
    {
    }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public string Name { get; private set; }
    public virtual ICollection<Order> Orders { get; init; } = new List<Order>();

    public void Edit(string name)
    {
        Name = name;
    }

    public Order AddOrder(Guid productId)
    {
        if (Orders.Any(o => o.ProductId.Equals(productId)))
            throw new Exception("user has already bought this product");

        var order = new Order(Id, productId);

        Orders.Add(order);

        return order;
    }
}