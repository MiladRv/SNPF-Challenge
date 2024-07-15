namespace SNPFD.Domain.Products;

public sealed class Product : AggregateRoot<Guid>
{
    //note: ef core needs parameterless constructor
    public Product()
    {
    }

    public Product(string title, uint inventoryCount, ulong price, double discount)
    {
        if (title.Length >= 40)
            throw new ArgumentOutOfRangeException(paramName: nameof(title),
                message: "must be less than 40 characters");

        Id = Guid.NewGuid();
        Title = title;
        InventoryCount = inventoryCount;
        Price = price;
        Discount = discount;
    }

    public string Title { get; private set; }
    public uint InventoryCount { get; private set; }
    public ulong Price { get; private set; }
    public double Discount { get; private set; }
}