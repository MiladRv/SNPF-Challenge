using Microsoft.Extensions.DependencyInjection;
using SNPFD.Application.Products;
using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Purchases;
using SNPFD.Application.Purchases.Contracts;
using SNPFD.Application.Users;
using SNPFD.Application.Users.Contracts;

namespace SNPFD.Application;

public static class ServiceRegistration
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUserAppService, UserAppService>();
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<IPurchaseAppService, PurchaseAppService>();
    }
}