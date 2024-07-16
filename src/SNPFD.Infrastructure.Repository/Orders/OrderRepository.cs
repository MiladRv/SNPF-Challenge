using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SNPFD.Application.Orders.Contracts;
using SNPFD.Application.Orders.Dtos;
using SNPFD.Domain.Orders;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.Orders;

public class OrderRepository(SNPFDDbContext dbContext, IMemoryCache memoryCache)
    : BaseRepository<Order, Guid>(dbContext, memoryCache), IOrderRepository
{
    public IEnumerable<PurchaseDto> GetByUserId(Guid userId, uint pageIndex, ushort pageSize)
    {
        return DbSet
            .AsNoTracking()
            .Where(order => order.UserId.Equals(userId))
            .OrderByDescending(order => order.CreationDate)
            .Skip((int)(pageIndex * pageSize))
            .Take(pageSize)
            .Include(order => order.Product)
            .Include(order => order.User)
            .Select(order => ToPurchaseDto(ref order));
    }

    private static PurchaseDto ToPurchaseDto(ref Order order)
    {
        return new PurchaseDto(order.Id,
            order.User.Name,
            order.ProductId,
            order.Product.Title,
            order.Product.Price,
            order.Product.DiscountedPrice,
            order.Id,
            order.CreationDate);
    }
}