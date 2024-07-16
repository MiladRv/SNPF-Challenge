using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Products.Dtos;
using SNPFD.Application.Users.Contracts;
using SNPFD.Application.Users.Dtos;

namespace SNPFD.WebApi.Workers;

/// <summary>
/// this worker will creat some initial data
/// </summary>
public sealed class SeedDataWorker : BackgroundService
{
    private readonly IUserAppService _userAppService;
    private readonly IProductAppService _productAppService;
    private const ushort SeedCount = 10;
    private readonly IServiceScope _serviceScope;
    
    public SeedDataWorker(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScope = serviceScopeFactory.CreateScope();

        _userAppService = _serviceScope.ServiceProvider.GetRequiredService<IUserAppService>();
        _productAppService = _serviceScope.ServiceProvider.GetRequiredService<IProductAppService>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stoppingToken"></param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        for (var i = 1; i < SeedCount; i++)
        {
            _ = await CreateSomeUser();
            _ = await CreateSomeProduct();
        }
        
        _serviceScope.Dispose();
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
            (ulong)random.NextInt64(1, ushort.MaxValue),
            random.Next(1, 100),
            (uint)random.Next(1, 5));

        return await _productAppService
            .CreateAsync(inputDto);
    }
}