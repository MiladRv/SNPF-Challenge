using SNPFD.Application.Products.Contracts;
using SNPFD.Domain.Products;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.Products;

public sealed class ProductRepository(SNPFDDbContext dbContext) :
    BaseRepository<Product, Guid>(dbContext), IProductRepository
{
}