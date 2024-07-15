using SNPFD.Domain.Users.Orders;

namespace SNPFD.Domain.Users;

public sealed class User : AggregateRoot<Guid>
{
    public ICollection<Order> Orders { get; private set; }
}