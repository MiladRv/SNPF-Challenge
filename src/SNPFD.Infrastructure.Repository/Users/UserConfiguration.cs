using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SNPFD.Domain.Users;
using SNPFD.Domain.Users.Orders;

namespace SNPFD.Infrastructure.Repository.Users;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(user => user.Id)
            .ValueGeneratedNever();
        
        builder
            .HasKey(user => user.Id);

        builder.OwnsMany(
            user => user.Orders, navigationBuilder =>
            {
                navigationBuilder
                    .Property(order => order.Id)
                    .ValueGeneratedNever();
                
                navigationBuilder
                    .WithOwner()
                    .HasForeignKey(order => order.UserId);
                
                navigationBuilder
                    .HasKey(order => order.Id);
                
                navigationBuilder
                    .ToTable(string.Concat(nameof(Order),"s"));
            });
    }
}