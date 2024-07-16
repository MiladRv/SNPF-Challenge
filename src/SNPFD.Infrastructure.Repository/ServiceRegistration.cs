using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SNPFD.Application;
using SNPFD.Application.Orders.Contracts;
using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Users.Contracts;
using SNPFD.Infrastructure.Repository.DbContexts;
using SNPFD.Infrastructure.Repository.Orders;
using SNPFD.Infrastructure.Repository.Products;
using SNPFD.Infrastructure.Repository.UnitOfWorks;
using SNPFD.Infrastructure.Repository.Users;

namespace SNPFD.Infrastructure.Repository;

public static class ServiceRegistration
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddMemoryCache(options => { options.ExpirationScanFrequency = TimeSpan.FromSeconds(2); });

        services.AddDbContext<SNPFDDbContext>(builder => builder
            // .UseInMemoryDatabase("SnappFood")
            .UseNpgsql("Server=localhost;Port=5432;Database=SnappFood_1;UserId=postgres;Password=postgres;")
            .EnableDetailedErrors()
        );
    }
}