using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SNPFD.Application.Products.Contracts;
using SNPFD.WebApi.Controllers.Products.Requests;

namespace SNPFD.WebApi.Controllers.Products;

/// <summary>
/// product end-points 
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public sealed class ProductsController(IProductAppService productAppService) : ControllerBase
{
    /// <summary>
    /// create a product
    /// </summary>
    /// <param name="requestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var inputDto = requestDto.ToInputDto();

        var productDto = await productAppService
            .CreateAsync(inputDto, cancellationToken);

        return Ok(productDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindById(Guid id,
        CancellationToken cancellationToken = default)
    {
        var productDto = await productAppService
            .FindByIdAsync(id, cancellationToken);

        return Ok(productDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditAsync([FromRoute] Guid id,
        EditProductRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var inputDto = requestDto.ToInputDto(id);

        var productDto = await productAppService
            .EditAsync(inputDto, cancellationToken);

        return Ok(productDto);
    }

    [HttpPatch("{id:guid}/inventoryCounts")]
    public async Task<IActionResult> EditInventoryCountAsync([FromRoute] Guid id,
        EditInventoryCountRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var productDto = await productAppService
            .EditInventoryCountAsync(id,
                requestDto.InventoryCount,
                cancellationToken);

        return Ok(productDto);
    }

    [HttpGet]
    public IActionResult GetAll(ushort pageIndex, [Range(1, 100)] ushort pageSize)
    {
        var products = productAppService
            .GetAll(pageIndex, pageSize);

        return Ok(products);
    }
}