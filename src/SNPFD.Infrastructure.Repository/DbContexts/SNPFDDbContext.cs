using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SNPFD.Domain.Products;
using SNPFD.Domain.Users;

namespace SNPFD.Infrastructure.Repository.DbContexts;

public sealed class SNPFDDbContext(DbContextOptions<SNPFDDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseLazyLoadingProxies();
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<User> Users { get; init; }
    public DbSet<Product> Products { get;init; }
}