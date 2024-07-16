using Moq;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SNPFD.Application.Products.Contracts;
using SNPFD.Domain.Products;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Test.Products;

internal static class ProductRepositorySetups
{
    public static Product SetupAddAsync(this Mock<IProductRepository> userRepositoryFake)
    {
        var randomizerText = new RandomizerText(new FieldOptionsText()
        {
            Max = 40,
            Min = 1
        });

        var randomNumber = new Random();

        var someProduct = new Product(randomizerText.Generate()!,
            (uint)randomNumber.Next(1, int.MaxValue),
            (ulong)randomNumber.Next(1, int.MaxValue),
            randomNumber.Next(1, 100));

        userRepositoryFake
            .Setup(repository => repository.AddAsync(someProduct, true, CancellationToken.None))
            .ReturnsAsync(someProduct);

        userRepositoryFake
            .Setup(repository => repository.GetByIdAsync(someProduct.Id, CancellationToken.None))
            .ReturnsAsync(someProduct);

        return someProduct;
    }
}