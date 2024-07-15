using Microsoft.AspNetCore.Mvc;
using SNPFD.Application.Users.Contracts;

namespace SNPFD.WebApi.Controllers.Users;

[Route("api/v1/[controller]")]
public class UsersController(IUserAppService userAppService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await userAppService.FindByIdAsync(id);
        
        return Ok(user);
    }
}