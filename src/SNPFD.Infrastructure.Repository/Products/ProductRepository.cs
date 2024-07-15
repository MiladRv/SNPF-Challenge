using Microsoft.EntityFrameworkCore;
using SNPFD.Application.Products.Contracts;
using SNPFD.Domain.Products;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.Products;

public sealed class ProductRepository(SNPFDDbContext dbContext) :
    BaseRepository<Product, Guid>(dbContext), IProductRepository
{
    public IEnumerable<Product> GetAll(ushort pageIndex, ushort pageSize)
    {
        return DbSet
            .AsNoTracking()
            .OrderBy(product => product.Title)
            .Skip(pageIndex * pageSize)
            .Take(pageSize);
    }
}