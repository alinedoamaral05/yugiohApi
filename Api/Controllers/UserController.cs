using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Services;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private UserService _userService;
    public UserController(IMapper mapper, UserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    //public async Task<IActionResult> Login(LoginUserDto dto)
    //{
    //    await _userService.Login(dto);
    //}

    [HttpPost]
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
