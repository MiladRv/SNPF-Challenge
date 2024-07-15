using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Products.Dtos;
using SNPFD.Application.Purchases.Contracts;
using SNPFD.Application.Users.Contracts;
using SNPFD.Application.Users.Dtos;

namespace SNPFD.WebApi.Workers;

public class SeedDataWorker : BackgroundService
{
    private readonly IUserAppService _userAppService;
    private readonly IProductAppService _productAppService;
    private readonly IPurchaseAppService _purchaseAppService;

    public SeedDataWorker(IServiceScopeFactory serviceScopeFactory)
    {
        var scope = serviceScopeFactory.CreateScope();

        _userAppService = scope.ServiceProvider.GetRequiredService<IUserAppService>();
        _productAppService = scope.ServiceProvider.GetRequiredService<IProductAppService>();
        _purchaseAppService = scope.ServiceProvider.GetRequiredService<IPurchaseAppService>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var user = await CreateSomeUser();
        var product = await CreateSomeProduct();
    }

    private async Task<UserDto> CreateSomeUser()
    {
        var someName = new RandomizerFullName(new FieldOptionsFullName()
        {
            Female = true,
            Male = true,
            UseNullValues = false
        }).Generate()!;

        return await _userAppService.CreateAsync(someName);
    }

    private async Task<ProductDto> CreateSomeProduct()
    {
        var someName = new RandomizerTextWords(new FieldOptionsTextWords()
        {
            Max = 4
        }).Generate()!;

        var random = new Random();

        var inputDto = new CreateProductInputDto(someName,
            (ulong)random.NextInt64(1, int.MaxValue),
            random.Next(1, 100),
            (uint)random.Next(1, int.MaxValue));

        return await _productAppService
            .CreateAsync(inputDto);
    }
}