using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Purchases.Contracts;
using SNPFD.Application.Purchases.Dtos;
using SNPFD.Application.Users.Contracts;
using SNPFD.Application.Users.Orders.Contracts;

namespace SNPFD.Application.Purchases;

public sealed class PurchaseAppService(
    IProductAppService productAppService,
    IOrderAppService orderAppService,
    IUserAppService userAppService) : IPurchaseAppService
{
    public async Task<PurchaseDto> CreateAsync(PurchaseInputDto inputDto,
        CancellationToken cancellationToken = default)
    {
        var productDto = await productAppService
            .DecreaseInventoryCount(inputDto.ProductId, cancellationToken);

        var orderDto = await orderAppService
            .CreateAsync(inputDto.ProductId,
                inputDto.UserId,
                cancellationToken);

        var userDto = await userAppService
            .FindByIdAsync(inputDto.UserId, cancellationToken);

        return new PurchaseDto(userDto.Id,
            userDto.Name,
            productDto.Id,
            productDto.Title,
            productDto.Price,
            orderDto.Id,
            orderDto.CreationDate);
    }
}