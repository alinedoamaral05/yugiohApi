using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("Duel")]
public class DuelController : ControllerBase
{
    private readonly IChallengeService<CreateChallengeDto, ReadChallengeDto, ChoseDeckDto> _chService;

    public DuelController(IChallengeService<CreateChallengeDto, ReadChallengeDto, ChoseDeckDto> challengeService)
    {
        _chService = challengeService;
    }

    [HttpPost]
    public async Task<IActionResult> Duel([FromBody] CreateChallengeDto dto)
    {
        try
        {
            var duel = await _chService.Create(dto);

            return Ok(duel);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost("{id}/Accept")]
    public async Task<IActionResult> Accept(int id)
    {
        try
        {
            var duel = await _chService.Accept(id);

            return Ok(duel);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost("{id}/Decline")]
    public async Task<IActionResult> Decline(int id)
    {
        try
        {
            var duel = await _chService.Decline(id);

            return Ok(duel);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost("{duelId}")]
    public async Task<IActionResult> SelectDeck(int duelId, [FromBody] ChoseDeckDto dto)
    {
        try
        {
            var duel = await _chService.SelectDeck(duelId, dto);

            return Ok(duel);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
} 