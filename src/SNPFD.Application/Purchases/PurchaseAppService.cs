using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Purchases.Contracts;
using SNPFD.Application.Purchases.Dtos;
using SNPFD.Application.Users.Contracts;
using SNPFD.Domain.Products;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Purchases;

public sealed class PurchaseAppService(
    IProductRepository productRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : IPurchaseAppService
{
    public async Task<PurchaseDto> CreateAsync(Guid userId, 
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        var product = await FindAndValidateProduct(productId, cancellationToken);

        var user = await FindAndValidateUser(userId, cancellationToken);

        product.DecreaseInventoryCount();

        var order = user.AddOrder(product.Id);

        await productRepository
            .UpdateAsync(product,
                saveChanges: false,
                cancellationToken: cancellationToken);

        await userRepository
            .UpdateAsync(user,
                saveChanges: false,
                cancellationToken: cancellationToken);

        await unitOfWork.CommitAsync();


        return new PurchaseDto(user.Id,
            user.Name,
            product.Id,
            product.Title,
            product.Price,
            order.Id,
            order.CreationDate);
    }


    private async Task<User> FindAndValidateUser(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var user = await userRepository
            .GetByIdAsync(userId, cancellationToken);

        if (user is null)
            throw new Exception("user not found");

        return user;
    }

    private async Task<Product> FindAndValidateProduct(Guid productId,
        CancellationToken cancellationToken = default)
    {
        var product = await productRepository
            .GetByIdAsync(productId, cancellationToken);

        if (product is null)
            throw new Exception("product not found");

        return product;
    }
}