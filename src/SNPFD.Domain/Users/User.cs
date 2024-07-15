using SNPFD.Domain.Orders;

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
}