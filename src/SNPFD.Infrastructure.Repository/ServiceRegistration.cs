using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SNPFD.Application;
using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Users.Contracts;
using SNPFD.Infrastructure.Repository.DbContexts;
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

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<SNPFDDbContext>(builder => builder
                .UseInMemoryDatabase("SnappFood")
            // .UseNpgsql("")
        );
    }
}