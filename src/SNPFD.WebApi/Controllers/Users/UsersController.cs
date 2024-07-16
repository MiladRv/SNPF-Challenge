using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SNPFD.Application.Orders.Contracts;
using SNPFD.Application.Users.Contracts;
using SNPFD.WebApi.Controllers.Users.Requests;

namespace SNPFD.WebApi.Controllers.Users;

/// <summary>
/// user's end-points
/// </summary>
/// <param name="userAppService"></param>
/// <param name="orderAppService"></param>
[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(
    IUserAppService userAppService,
    IOrderAppService orderAppService) : ControllerBase
{
    /// <summary>
    /// get the user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindById(Guid id)
    {
        var user = await userAppService.FindByIdAsync(id);

        return Ok(user);
    }

    /// <summary>
    /// create a user
    /// </summary>
    /// <param name="requestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var userDto = await userAppService
            .CreateAsync(requestDto.Name, cancellationToken);

        return Ok(userDto);
    }

    /// <summary>
    /// edit user's details
    /// </summary>
    /// <param name="id"></param>
    /// <param name="requestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// get all of users
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAll([FromQuery] uint pageIndex = 0,
        [FromQuery] ushort pageSize = 100)
    {
        var usersDto = userAppService
            .GetAll(pageIndex, pageSize);

        return Ok(usersDto);
    }

    /// <summary>
    /// get orders of user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
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