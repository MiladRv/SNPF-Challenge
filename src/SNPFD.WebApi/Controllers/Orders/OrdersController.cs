using Microsoft.AspNetCore.Mvc;
using SNPFD.Application.Orders.Contracts;
using SNPFD.WebApi.Controllers.Purchases.Requests;

namespace SNPFD.WebApi.Controllers.Orders;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController(IOrderAppService orderAppService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> BuyAsync([FromBody] BuyRequestDto requestDto)
    {
        var purchaseDto = await orderAppService
            .CreateAsync(requestDto.UserId, requestDto.ProductId);

        return Ok(purchaseDto);
    }
    
}