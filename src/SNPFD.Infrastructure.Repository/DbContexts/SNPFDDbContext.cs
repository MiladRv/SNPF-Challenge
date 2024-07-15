using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SNPFD.Domain.Products;
using SNPFD.Domain.Users;

namespace SNPFD.Infrastructure.Repository.DbContexts;

public class SNPFDDbContext : DbContext
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
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
}