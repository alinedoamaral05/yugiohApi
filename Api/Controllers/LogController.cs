using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("cards")]
public class LogController : ControllerBase
{
    private readonly ICardService _cardService;
    private readonly IUserService<LoginUserDto> _userService;
    public LogController(ICardService cardService, IUserService<LoginUserDto> userService)
    {
        _cardService = cardService;
        _userService = userService;
    }

    [HttpGet("AllCardsCount")]
    public async Task<IActionResult> GetTotalCards()
    {
        try
        {
            var totalCards = await _cardService.GetTotalCards();
            return Ok(totalCards);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("AllUsersCount")]
    public async Task<IActionResult> GetTotalUsers()
    {
        try
        {
            var totalUsers = await _userService.GetTotalUsers();
            return Ok(totalUsers);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

}