using SNPFD.Application.Products.Dtos;
using SNPFD.Domain.Products;

namespace SNPFD.Application.Products.Contracts;

internal static class ProductExtensions
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto(product.Id,
            product.Title,
            product.InventoryCount,
            product.Price,
            product.Discount);
    }
}