using SNPFD.Domain.Users.Orders;

namespace SNPFD.Domain.Users;

public sealed class User : AggregateRoot<Guid>
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
    public ICollection<Order> Orders { get; set; }

    public void Edit(string name)
    {
        Name = name;
    }
}