using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

/// <summary>
/// Classe para gerenciar as requisições de Deck.
/// </summary>
[ApiController]
[Route("decks")]
public class DeckController : ControllerBase
{
    private readonly IDeckService _deckService;

    public DeckController(IDeckService deckService)
    {
        _deckService = deckService;
    }

    /// <summary>
    /// Retorna todos os deck do banco de dados.
    /// </summary>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDecks()
    {
        try
        {
            var decks = await _deckService.FindAll();

            return Ok(decks);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Retorna um deck específico do banco de dados.
    /// </summary>
    /// <param name="id">Id do deck para ser retornado.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso."></response>
    /// <response code="404">Caso o id não seja encontrado.</response>
    [HttpGet("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDeckById(int id)
    {
        try
        {
            var deck = await _deckService.FindById(id);

            return Ok(deck);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Cria um deck no banco de dados.
    /// </summary>
    /// <param name="dto">Possui os campos necessários para criar um deck.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="201">Caso a requisição seja concluída com sucesso.</response>
    /// <response code="400">Caso o deck já exista, ou as informações passadas estejam erradas.</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostDeck([FromBody] CreateDeckDto dto)
    {
        try
        {
            var deck = await _deckService.Create(dto);

            return CreatedAtAction(
                nameof(GetDeckById),
                new { id = deck.Id },
                    deck);
        }
        catch (Exception ex) 
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza um Deck, passando o id e as informações que serão atualizadas. Caso o id não seja encontrado, 
    /// cria um novo Deck.
    /// </summary>
    /// <param name="id">Id do deck para ser atualizado.</param>
    /// <param name="dto">Possui os campos necessários para atualizar o deck.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="204">Caso a requisição seja concluída com sucesso.</response>
    /// <response code="400">Caso o deck já exista, ou as informações passadas estejam erradas.</response>
    [HttpPut("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDeck(int id, [FromBody] UpdateDeckDto dto)
    {
        try
        {
            await _deckService.UpdateById(dto, id);

            return NoContent();

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Deleta um deck do banco de dados.
    /// </summary>
    /// <param name="id">O id do deck para ser deletado.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="204">Caso a requisição seja feita com sucesso.</response>
    /// <response code="404">Caso o deck não seja encontrado.</response>
    [HttpDelete("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDeck(int id)
    {
        try
        {
            await _deckService.DeleteById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Adiciona cartas a um deck.
    /// </summary>
    /// <param name="id">Id do deck para ser adicionado as cartas.</param>
    /// <param name="cardIds">Ids das cartas para ser adicionadas ao deck.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso.</response>
    /// <response code="404">Caso o deck não seja encontrado.</response>
    [HttpPost("{id:int}/cards")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddCardsToDeck(int id, [FromBody] List<int> cardIds)
    {
        try
        {
            var deck = await _deckService.AddCardsToDeck(id, cardIds);

            return Ok(deck);
        }
        catch(Exception exception)
        {
            return Problem(exception.Message);
        }
    }
}
