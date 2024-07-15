using SNPFD.Application.Purchases.Dtos;

namespace SNPFD.Application.Purchases.Contracts;

public interface IPurchaseAppService
{
    Task<PurchaseDto> CreateAsync(PurchaseInputDto inputDto,
        CancellationToken cancellationToken = default);
}