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

    /// <summary>
    /// Retorna todos os desafios do banco de dados.
    /// </summary>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>
    /// <response code="400">Caso a requisição falhe.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllChallenge()
    {
        try
        {
            var challenges = await _chService.FindAll();

            return Ok(challenges);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retorna um desafio específico do banco de dados.
    /// </summary>
    /// <param name="id">O id do desafio para ser retornado.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>
    /// <response code="400">Caso a requisição falhe.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var challenge = await _chService.FindById(id);

        return Ok(challenge);
    }

    /// <summary>
    /// Cria um desafio.
    /// </summary>
    /// <param name="dto">Possui os campos necessários para criar um desafio.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>
    /// <response code="400">Caso a requisição falhe</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Aceita um desafio.
    /// </summary>
    /// <param name="id">O id do desafio para ser aceito.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>]
    /// <response code="400">Caso a requisição falhe.</response>
    [HttpPost("{id}/Accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Recusa um duelo.
    /// </summary>
    /// <param name="id">Id do duelo para ser recusado.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>
    /// <response code="400">Caso a requisição falhe.</response>
    [HttpPost("{id}/Decline")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Seleciona os decks para um duelo.
    /// </summary>
    /// <param name="duelId">Duelo para selecionar os decks.</param>
    /// <param name="dto">Possui os campos necessários para selecionar os decks.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso.</response>
    /// <response code="400">Caso a requisição falhe.</response>
    [HttpPost("{duelId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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