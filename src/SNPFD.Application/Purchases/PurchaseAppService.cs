using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Purchases.Contracts;
using SNPFD.Application.Purchases.Dtos;
using SNPFD.Application.Users.Contracts;

namespace SNPFD.Application.Purchases;

public sealed class PurchaseAppService(
    IProductAppService productAppService,
    IOrderAppService orderAppService) : IPurchaseAppService
{
    public async Task<PurchaseDto> CreateAsync(PurchaseInputDto inputDto,
        CancellationToken cancellationToken = default)
    {
        // await productAppService
        //     .DecreaseInventoryCount(inputDto.ProductId, cancellationToken);

        throw new NotImplementedException();

    }
}