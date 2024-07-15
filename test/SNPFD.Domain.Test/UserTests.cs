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
        var someName = new RandomizerText(new FieldOptionsText()
        {
            Max = 40
        }).Generate();

        // act
        var actual = new User(someName);

        // assert
        actual
            .Should()
            .Match<User>(options =>
                options.Id != Guid.Empty &&
                !string.IsNullOrWhiteSpace(options.Name));
    }

    [Fact]
    public void LengthOfName_GreaterOrEqualForty_ThrowException()
    {
        // arrange
        var someName = new RandomizerText(new FieldOptionsText()
        {
            Max = int.MaxValue,
            Min = 40
        }).Generate();

        // act
        void Act()
        {
            var _ = new User(someName!);
        }

        // assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(Act);

        exception
            .ParamName
            .Should()
            .Be("name");
    }
}