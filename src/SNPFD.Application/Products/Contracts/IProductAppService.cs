using SNPFD.Application.Products.Dtos;

namespace SNPFD.Application.Products.Contracts;

public interface IProductAppService
{
    Task<ProductDto> CreateAsync(CreateProductInputDto inputDto,
        CancellationToken cancellationToken = default);

    Task<ProductDto> FindByIdAsync(Guid productId,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid productId,
        CancellationToken cancellationToken = default);

    Task<ProductDto> EditAsync(EditProductInputDto inputDto,
        CancellationToken cancellationToken = default);

    Task<ProductDto> DecreaseInventoryCount(Guid productId,
        CancellationToken cancellationToken = default);
}