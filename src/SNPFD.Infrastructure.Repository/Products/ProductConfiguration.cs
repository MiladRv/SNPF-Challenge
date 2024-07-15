using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SNPFD.Domain.Products;

namespace SNPFD.Infrastructure.Repository.Products;

public sealed class ProductConfiguration :IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(product => product.Id);

        builder
            .Property(product => product.Title)
            .IsRequired()
            .IsUnicode();
    }
}