using SNPFD.Domain.Orders;

namespace SNPFD.Domain.Users;

public sealed class User : AggregateRoot<Guid>
{
    public User(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public ICollection<Order> Orders { get; private set; } = new List<Order>();
}