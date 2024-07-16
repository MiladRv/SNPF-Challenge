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

    /// <summary>
    /// get a product by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindById(Guid id,
        CancellationToken cancellationToken = default)
    {
        var productDto = await productAppService
            .FindByIdAsync(id, cancellationToken);

        return Ok(productDto);
    }

    /// <summary>
    /// edit the product's details
    /// </summary>
    /// <param name="id"></param>
    /// <param name="requestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// edit inventory count of product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="requestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// get all of products
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAll(   [FromQuery] uint pageIndex = 0,
        [Range(1, 100)] [FromQuery] ushort pageSize = 50)
    {
        var products = productAppService
            .GetAll(pageIndex, pageSize);

        return Ok(products);
    }
}