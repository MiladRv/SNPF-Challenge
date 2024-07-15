using FluentAssertions;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SNPFD.Domain.Products;

namespace SNPFD.Domain.Test;

public class ProductTests
{
    [Fact]
    public void Constructor_FillProperties()
    {
        // arrange
        var someTitle = new RandomizerText(new FieldOptionsText()
        {
            Max = 39
        }).Generate()!;

        var someInventoryCount = new RandomizerNumber<int>(new FieldOptionsInteger()
        {
            Min = 0
        }).Generate()!;

        var somePrice = new RandomizerNumber<long>(new FieldOptionsLong()
        {
            Min = 0
        }).Generate()!;

        var someDiscount = new RandomizerNumber<double>(new FieldOptionsDouble()
        {
            Min = 0
        }).Generate()!;

        // act
        var actual = new Product(someTitle,
            (uint)someInventoryCount.Value,
            (ulong)somePrice.Value,
            someDiscount.Value);

        // assert
        actual
            .Should()
            .Match<Product>(options =>
                options.Id != Guid.Empty &&
                options.Title.Equals(someTitle) &&
                options.InventoryCount == someInventoryCount &&
                options.Price == (ulong)somePrice &&
                Math.Abs(options.Discount - someDiscount.Value) == 0);
    }

    [Fact]
    public void LengthOfTitle_GreaterOrEqualForty_ThrowException()
    {
        // arrange
        var someTitle = new RandomizerText(new FieldOptionsText()
        {
            Max = int.MaxValue,
            Min = 40
        }).Generate()!;

        // act
        void Act()
        {
            var _ = new ProductBuilder()
                .WithTitle(someTitle)
                .Build();
        }

        // assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(Act);

        exception
            .ParamName
            .Should()
            .Be("title");
    }
}