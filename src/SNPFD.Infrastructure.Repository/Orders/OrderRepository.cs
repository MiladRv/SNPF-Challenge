using Microsoft.EntityFrameworkCore;
using SNPFD.Application.Orders.Contracts;
using SNPFD.Domain.Orders;
using SNPFD.Infrastructure.Repository.DbContexts;

namespace SNPFD.Infrastructure.Repository.Orders;

public class OrderRepository(SNPFDDbContext dbContext)
    : BaseRepository<Order, Guid>(dbContext), IOrderRepository
{
    public IEnumerable<Order> GetByUserId(Guid userId, uint pageIndex, ushort pageSize)
    {
        return DbSet
            .AsNoTracking()
            .Where(order => order.UserId.Equals(userId))
            .OrderByDescending(order => order.CreationDate)
            .Skip((int)(pageIndex * pageSize))
            .Take(pageSize);
    }
}