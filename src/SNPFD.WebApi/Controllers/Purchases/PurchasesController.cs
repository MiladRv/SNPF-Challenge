using Microsoft.AspNetCore.Mvc;
using SNPFD.Application.Purchases.Contracts;
using SNPFD.WebApi.Controllers.Purchases.Requests;

namespace SNPFD.WebApi.Controllers.Purchases;

[ApiController]
[Route("api/v1/[controller]")]
public class PurchasesController(IPurchaseAppService purchaseAppService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> BuyAsync([FromBody] BuyRequestDto requestDto)
    {
        var purchaseDto = await purchaseAppService
            .CreateAsync(requestDto.UserId, requestDto.ProductId);

        return Ok(purchaseDto);
    }
}