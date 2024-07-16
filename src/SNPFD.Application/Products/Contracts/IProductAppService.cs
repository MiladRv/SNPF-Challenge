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

    Task<ProductDto> EditInventoryCountAsync(Guid productId, 
        uint inventoryCount, 
        CancellationToken cancellationToken = default);

    IEnumerable<ProductDto> GetAll(uint pageIndex, ushort pageSize);
}