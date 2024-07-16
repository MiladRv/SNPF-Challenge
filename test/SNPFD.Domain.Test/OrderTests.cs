using FluentAssertions;
using SNPFD.Domain.Orders;

namespace SNPFD.Domain.Test;

public sealed class OrderTests
{
    [Fact]
    public void Constructor_FillProperties()
    {
        // arrange
        var someCreationDate = DateTime.UtcNow;
        var someProductId = Guid.NewGuid();
        var someUserId = Guid.NewGuid();

        // act
        var actual = new Order(someUserId, someProductId);

        // assert
        actual
            .Should()
            .Match<Order>(options =>
                options.Id != Guid.Empty &&
                options.ProductId.Equals(someProductId) &&
                options.UserId.Equals(someUserId) &&
                options.CreationDate.Subtract(someCreationDate) < TimeSpan.FromSeconds(1));
    }
}