using SNPFD.Domain.Orders;

namespace SNPFD.Domain.Users;

public sealed class User : AggregateRoot<Guid>
{
    //note: ef core needs parameterless constructor
    public User()
    {
    }

    public User(string name)
    {
        if (name.Length >= 40)
            throw new ArgumentOutOfRangeException(paramName: nameof(name),
                message: "must be less than 40 characters");

        Id = Guid.NewGuid();
        Name = name;
    }

    public string Name { get; private set; }
    public ICollection<Order> Orders { get; set; }
}