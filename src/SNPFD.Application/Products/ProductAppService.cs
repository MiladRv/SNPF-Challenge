using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Products.Dtos;
using SNPFD.Domain.Products;

namespace SNPFD.Application.Products;

public sealed class ProductAppService(IProductRepository repository) : IProductAppService
{
    public async Task<ProductDto> CreateAsync(CreateProductInputDto inputDto,
        CancellationToken cancellationToken = default)
    {
        var product = new Product(inputDto.Title,
            inputDto.InventoryCount,
            inputDto.Price,
            inputDto.Discount);

        await repository.AddAsync(product,
            cancellationToken: cancellationToken);

        return product.ToDto();
    }

    public async Task<ProductDto> FindByIdAsync(Guid productId,
        CancellationToken cancellationToken = default)
    {
        var product = await FindAndValidate(productId, cancellationToken);

        return product.ToDto();
    }

    public async Task DeleteAsync(Guid productId,
        CancellationToken cancellationToken = default)
    {
        var product = await FindAndValidate(productId,
            cancellationToken);

        await repository
            .DeleteAsync(product, cancellationToken: cancellationToken);
    }

    public async Task<ProductDto> EditAsync(EditProductInputDto inputDto,
        CancellationToken cancellationToken = default)
    {
        var product = await FindAndValidate(inputDto.Id,
            cancellationToken);

        product.Edit(inputDto.Title,
            inputDto.Price,
            inputDto.Discount);

        await repository
            .UpdateAsync(product, cancellationToken: cancellationToken);

        return product.ToDto();
    }

 
    public async Task<ProductDto> EditInventoryCountAsync(Guid productId, uint inventoryCount, CancellationToken cancellationToken = default)
    {
        var product = await FindAndValidate(productId, cancellationToken);

        product.EditInventoryCount(inventoryCount);

        await repository
            .UpdateAsync(product, cancellationToken: cancellationToken);

        return product.ToDto();
    }

    public IEnumerable<ProductDto> GetAll(ushort pageIndex, ushort pageSize)
    {
        return repository
            .GetAll(pageIndex, pageSize)
            .Select(product => product.ToDto());
    }

    private async Task<Product> FindAndValidate(Guid productId,
        CancellationToken cancellationToken = default)
    {
        var product = await repository
            .GetByIdAsync(productId, cancellationToken);

        if (product is null)
            throw new Exception("product not found");

        return product;
    }
}