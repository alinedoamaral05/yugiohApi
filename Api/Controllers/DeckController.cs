using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("decks")]
public class DeckController : ControllerBase
{
    private readonly IDeckService _deckService;

    public DeckController(IDeckService deckService)
    {
        _deckService = deckService;
    }

    [HttpGet]
    [Authorize]
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
    [HttpGet("{id:int}")]
    [Authorize]
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
    [HttpPost]
    [Authorize]
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
    [HttpPut("{id:int}")]
    [Authorize]
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
    [HttpDelete("{id:int}")]
    [Authorize]
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
    [HttpPost("{id:int}/cards")]
    [Authorize]
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
