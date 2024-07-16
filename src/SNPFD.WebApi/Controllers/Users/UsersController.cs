using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SNPFD.Application.Orders.Contracts;
using SNPFD.Application.Users.Contracts;
using SNPFD.WebApi.Controllers.Users.Requests;

namespace SNPFD.WebApi.Controllers.Users;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(
    IUserAppService userAppService,
    IOrderAppService orderAppService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await userAppService.FindByIdAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var userDto = await userAppService
            .CreateAsync(requestDto.Name, cancellationToken);

        return Ok(userDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditAsync([FromRoute] Guid id,
        [FromBody] EditUserRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var userDto = await userAppService
            .EditAsync(id,
                requestDto.Name,
                cancellationToken);

        return Ok(userDto);
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] uint pageIndex = 0,
        [FromQuery] ushort pageSize = 100)
    {
        var usersDto = userAppService
            .GetAll(pageIndex, pageSize);

        return Ok(usersDto);
    }

    [HttpGet("{id:guid}/orders")]
    public IActionResult GetUserOrders([FromRoute] Guid id,
        [FromQuery] uint pageIndex = 0,
        [Range(1, 00)] [FromQuery] ushort pageSize = 50)
    {
        var orders = orderAppService.FindByUserId(id,
            pageIndex,
            pageSize);

        return Ok(orders);
    }
}