using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SNPFD.Application.Products.Contracts;
using SNPFD.Domain.Products;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.Products;

public sealed class ProductRepository(SNPFDDbContext dbContext, IMemoryCache memoryCache) :
    BaseRepository<Product, Guid>(dbContext, memoryCache), IProductRepository
{
    public IEnumerable<Product> GetAll(uint pageIndex, ushort pageSize)
    {
        return DbSet
            .AsNoTracking()
            .OrderBy(product => product.Title)
            .Skip((int)(pageIndex * pageSize))
            .Take(pageSize);
    }

    public bool ExistProductTitle(string title)
    {
        return DbSet
            .AsNoTracking()
            .Any(product => product.Title.Equals(title));
    }
}