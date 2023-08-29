using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Services;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(CreateUserDto dto)
    {
        try
        {
            var user = await _userService.Create(dto);
            return Ok(user);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
