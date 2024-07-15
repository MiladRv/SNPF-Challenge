using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SNPFD.Domain.Products;

namespace SNPFD.Domain.Test.Products;

public sealed class ProductBuilder
{
    private string Title { get; set; }

    private uint InventoryCount { get; set; }

    private ulong Price { get; set; }

    private double Discount { get; set; }

    public ProductBuilder()
    {
        Title = new RandomizerText(new FieldOptionsText()
        {
            Max = 40
        }).Generate()!;

        InventoryCount = (uint)new RandomizerNumber<int>(new FieldOptionsInteger()
        {
            Min = 0
        }).Generate()!;

        Price = (ulong)new RandomizerNumber<long>(new FieldOptionsLong()
        {
            Min = 0
        }).Generate()!;

        Discount = (double)new RandomizerNumber<double>(new FieldOptionsDouble()
        {
            Min = 0
        }).Generate()!;
    }

    public ProductBuilder WithTitle(string title)
    {
        Title = title;
        return this;
    }

    public ProductBuilder WithInventoryCount(uint inventoryCount)
    {
        InventoryCount = inventoryCount;
        return this;
    }

    public ProductBuilder WithPrice(ulong price)
    {
        Price = price;
        return this;
    }

    public ProductBuilder WithDiscount(double discount)
    {
        Discount = discount;
        return this;
    }

    public Product Build()
    {
        return new Product(Title,
            InventoryCount,
            Price,
            Discount);
    }
}