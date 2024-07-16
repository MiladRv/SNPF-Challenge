using Microsoft.AspNetCore.Mvc;
using SNPFD.Application.Orders.Contracts;
using SNPFD.WebApi.Controllers.Orders.Requests;

namespace SNPFD.WebApi.Controllers.Orders;

/// <summary>
/// order's end-points 
/// </summary>
/// <param name="orderAppService"></param>
[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController(IOrderAppService orderAppService) : Controller
{
    /// <summary>
    /// buy the product
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> BuyAsync([FromBody] BuyRequestDto requestDto)
    {
        var purchaseDto = await orderAppService
            .CreateAsync(requestDto.UserId, requestDto.ProductId);

        return Ok(purchaseDto);
    }
    
}