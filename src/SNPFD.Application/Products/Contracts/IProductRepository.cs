using SNPFD.Domain.Products;

namespace SNPFD.Application.Products.Contracts;

public interface IProductRepository : IBaseRepository<Product,Guid>
{
    
}