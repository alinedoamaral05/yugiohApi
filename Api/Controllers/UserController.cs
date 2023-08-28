using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController: ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser(CreateUserDto dto)
    {
        
    }
}
