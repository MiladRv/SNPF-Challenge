using SNPFD.Application.Orders.Contracts;
using SNPFD.Application.Orders.Dtos;
using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Users.Contracts;
using SNPFD.Domain.Orders;
using SNPFD.Domain.Products;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Orders;

public sealed class OrderAppService(
    IProductRepository productRepository,
    IUserRepository userRepository,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork) : IOrderAppService
{
    public async Task<PurchaseDto> CreateAsync(Guid userId,
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        var product = await FindAndValidateProduct(productId, cancellationToken);

        var user = await FindAndValidateUser(userId, cancellationToken);

        product.DecreaseInventoryCount();

        var order = new Order(user.Id, product.Id);

        await productRepository
            .UpdateAsync(product,
                saveChanges: false,
                cancellationToken: cancellationToken);

        await orderRepository
            .AddAsync(order,
                saveChanges: false,
                cancellationToken: cancellationToken);

        await unitOfWork.CommitAsync();

        return order.ToPurchaseDto();
    }

    public IEnumerable<PurchaseDto> FindByUserId(Guid userId,
        uint pageIndex = 0,
        ushort pageSize = 50)
    {
        return orderRepository
            .GetByUserId(userId, pageIndex, pageSize)
            .Select(order => order.ToPurchaseDto());
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