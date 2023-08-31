using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

/// <summary>
/// Classe para gerenciar as requisições de log.
/// </summary>
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

    /// <summary>
    /// Retorna o total de cartas no banco de dados.
    /// </summary>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluído com sucesso.</response>
    [HttpGet("AllCardsCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
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

    /// <summary>
    /// Retorna o total de usuários no banco de dados.
    /// </summary>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluído com sucesso.</response>
    [HttpGet("AllUsersCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
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