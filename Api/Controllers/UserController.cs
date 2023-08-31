using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserService<LoginUserDto> _userService;
    public UserController(IUserService<LoginUserDto> userService)
    {
        _userService = userService;
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(token);
    }

    [HttpPost("register")]
    [AllowAnonymous]
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
