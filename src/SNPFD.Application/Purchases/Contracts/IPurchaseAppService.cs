using SNPFD.Application.Purchases.Dtos;

namespace SNPFD.Application.Purchases.Contracts;

public interface IPurchaseAppService
{
    Task<PurchaseDto> CreateAsync(Guid userId,
        Guid productId,
        CancellationToken cancellationToken = default);
}