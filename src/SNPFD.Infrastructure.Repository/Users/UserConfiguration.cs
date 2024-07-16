using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SNPFD.Domain.Users;

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

        }
}