using Microsoft.EntityFrameworkCore;
using SNPFD.Application.Products.Contracts;
using SNPFD.Domain.Products;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository;

public sealed class ProductRepository(SNPFDDbContext dbContext) :
    BaseRepository<Product, Guid>(dbContext), IProductRepository
{
}