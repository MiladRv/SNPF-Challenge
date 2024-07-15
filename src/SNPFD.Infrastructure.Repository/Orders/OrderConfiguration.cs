using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SNPFD.Domain.Orders;
using SNPFD.Domain.Products;
using SNPFD.Domain.Users;

namespace SNPFD.Infrastructure.Repository.Orders;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(order => order.Id);

        builder
            .Property(order => order.Id)
            .ValueGeneratedNever();

        builder
            .HasOne<User>(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(order => order.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Product>(order => order.Product);
    }
}