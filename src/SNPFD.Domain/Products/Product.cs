namespace SNPFD.Domain.Products;

public class Product : AggregateRoot<Guid>
{
    //note: ef core needs parameterless constructor
    public Product()
    {
    }

    public Product(string title,
        uint inventoryCount,
        ulong price,
        double discount)
    {
        ValidateTitle(title);

        Id = Guid.NewGuid();
        Title = title;
        InventoryCount = inventoryCount;
        Price = price;
        Discount = discount;
    }

    public void Edit(string title,
        ulong price,
        double discount)
    {
        ValidateTitle(title);

        Title = title;
        Price = price;
        Discount = discount;
    }

    public string Title { get; private set; }
    public uint InventoryCount { get; private set; }
    public ulong Price { get; private set; }
    public double Discount { get; private set; }


    private static void ValidateTitle(string title)
    {
        if (title.Length >= 40)
            throw new ArgumentOutOfRangeException(paramName: nameof(title),
                message: "must be less than 40 characters");
    }

    public void DecreaseInventoryCount()
    {
        if (InventoryCount == 0)
            throw new ArgumentOutOfRangeException(nameof(InventoryCount), "inventory count is not enough");

        InventoryCount--;
    }

    public void EditInventoryCount(uint inventoryCount)
    {
        InventoryCount = inventoryCount;
    }
}