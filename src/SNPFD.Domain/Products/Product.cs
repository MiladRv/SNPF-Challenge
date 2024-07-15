namespace SNPFD.Domain.Products;

public sealed class Product : AggregateRoot<Guid>
{
    // efcore needs parameterless constructor
    public Product()
    {
        
    }
    public Product(string title, uint inventoryCount, ulong price, double discount)
    {
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