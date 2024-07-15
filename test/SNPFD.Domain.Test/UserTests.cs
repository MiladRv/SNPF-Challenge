using FluentAssertions;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SNPFD.Domain.Users;

namespace SNPFD.Domain.Test;

public sealed class UserTests
{
    [Fact]
    public void Constructor_FillProperties()
    {
        // arrange
        var someName = new RandomizerFullName(new FieldOptionsFullName())
            .Generate()!;

        // act
        var actual = new User(someName);

        // assert
        actual
            .Should()
            .Match<User>(options =>
                options.Id != Guid.Empty &&
                options.Name.Equals(someName));
    }
}