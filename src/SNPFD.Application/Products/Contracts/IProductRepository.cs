using SNPFD.Domain.Products;

namespace SNPFD.Application.Products.Contracts;

public interface IProductRepository : IBaseRepository<Product,Guid>
{
    IEnumerable<Product> GetAll(uint pageIndex, ushort pageSize);
    bool ExistProductTitle(string title);
}